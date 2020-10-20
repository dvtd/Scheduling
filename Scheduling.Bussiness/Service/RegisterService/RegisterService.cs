using AutoMapper;
using Scheduling.Data.Dtos.ExamGroup;
using Scheduling.Data.Dtos.Register;
using Scheduling.Data.Models;
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

        public async Task<RegisterDto> GetListRegisterByEmployee(RegisterDto dto)
        {
            RegisterDto result = dto;
            IEnumerable<Register> listRegister = await _unitOfWork.RegisterRepository.Get(
                filter: el => el.EmpId == result.EmpId && el.ExamGroup.ExamId == result.ExamId, includeProperties: "ExamGroup");
            var listExamGroup = listRegister
                .GroupBy(el => el.EmpId)
                .OrderBy(el => el.OrderBy(e => e.ExamGroup.ExamDate)
                                  .ThenBy(e => e.ExamGroup.TimeBegin));
            foreach(var group in listExamGroup)
            {
                foreach(Register reg in group)
                {
                    result.ListExamGroup.Add(_mapper.Map<ExamGroupDto>(reg.ExamGroup));
                }
            }
            return result;
        }

        public async Task<bool> RegisterExamGroup(List<RegisterDto> listRegisterRequest,int examId)
        {
            if (listRegisterRequest != null)
            {
                // Add ExamGroupId in List Register to Temp then Get List Exam Group In Session with ExamGroupID
                var listExamGroupInRegisterRequest = listRegisterRequest.GroupBy(el => el.ExamGroupId);
                List<int?> temp = new List<int?>();
                foreach(var item in listExamGroupInRegisterRequest)
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
                    if (listRegister != null || listRegister.Count() != 0)
                    {
                        // Check if number of examGroup in Session is bigger than in Register then insert to Result list
                        if (ex.Count() <= listRegister.Count())
                        {
                            throw new Exception("Can not register");
                        }
                    }
                }

                List<Register> listEntity = _mapper.Map<List<Register>>(listRegisterRequest);
                foreach(Register entity in listEntity)
                {
                    _unitOfWork.RegisterRepository.Add(entity);
                }
            }
            return await _unitOfWork.SaveAsync() > 0;
        }


    }
}
