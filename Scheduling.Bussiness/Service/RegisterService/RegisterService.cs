using AutoMapper;
using Scheduling.Data.Dtos.ExamGroup;
using Scheduling.Data.Dtos.Register;
using Scheduling.Data.Models;
using Scheduling.Data.Helper;
using Scheduling.Data.Repository;
using Scheduling.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Bussiness.Service.RegisterService
{
    public class RegisterService : BaseService<Register, RegisterDto>, IRegisterService
    {
        public RegisterService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override IGenericRepository<Register> _reponsitory => _unitOfWork.RegisterRepository;

        public async Task<IEnumerable<RegisterDto>> GetListRegisterByEmployee(int examId, int empId)
        {
            IEnumerable<Register> result = await _unitOfWork.RegisterRepository.Get(
                filter: el => el.EmpId == empId && el.ExamGroup.ExamId == examId && el.Status != AppConstants.Register.APPROVED,
                includeProperties: "ExamGroup",
                orderBy: el => el.OrderBy(e => e.ExamGroup.ExamDate).ThenBy(e => e.ExamGroup.TimeBegin));
            return _mapper.Map<IEnumerable<RegisterDto>>(result);
        }


        public async Task<bool> RegisterExamGroup(List<RegisterDto> listRegisterRequest, int examId)
        {
            if (listRegisterRequest != null)
            {
                // set status all list request to PENDING const
                foreach (var el in listRegisterRequest)
                {
                    el.Status = AppConstants.Register.PENDING;
                }

                // Add ExamGroupId in List Register to Temp then Get List Exam Group In Session with ExamGroupID
                var listExamGroupInRegisterRequest = listRegisterRequest.GroupBy(el => el.ExamGroupId);
                List<int?> temp = new List<int?>();
                foreach (var item in listExamGroupInRegisterRequest)
                {
                    temp.Add((int)item.Key);
                }
                // Get List Exam Group in Session
                var listExamGroupInSession = (await _unitOfWork.ExamSessionRepository
                    .Get(filter: el => el.ExamGroup.ExamId == examId && temp.Contains(el.ExamGroupId), includeProperties: "ExamGroup")).GroupBy(el => el.ExamGroupId);

                foreach (var ex in listExamGroupInSession)
                {
                    // Get list register by exam group Id
                    IEnumerable<Register> listRegister = (await _unitOfWork.RegisterRepository
                                        .Get(filter: el => el.ExamGroupId == ex.Key));
                    // If register has data
                    if (listRegister.Count() != 0)
                    {
                        // Check if number of examGroup in Session is bigger than in Register then insert to Result list
                        if (ex.Count() <= listRegister.Count())
                        {
                            throw new Exception("Can not register");
                        }
                    }
                }

                List<Register> listEntity = _mapper.Map<List<Register>>(listRegisterRequest);
                foreach (Register entity in listEntity)
                {
                    _unitOfWork.RegisterRepository.Add(entity);
                }
            }
            return await _unitOfWork.SaveAsync() > 0;
        }
    }
}
