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

        public async Task<bool> RegisterExamGroup(List<RegisterDto> listRegister)
        {
            if (listRegister != null)
            {
                List<Register> listEntity = _mapper.Map<List<Register>>(listRegister);
                foreach(Register dto in listEntity)
                {
                    _unitOfWork.RegisterRepository.Add(dto);
                }
            }
            return await _unitOfWork.SaveAsync() > 0;
        }


    }
}
