using AutoMapper;
using Scheduling.Data.Dtos.EmployeeRalate;
using Scheduling.Data.Models;
using Scheduling.Data.Repository;
using Scheduling.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Scheduling.Data.Dtos.ExamSession;

namespace Scheduling.Bussiness.Service.EmployeeRelatedService
{
    public class EmployeeRelatedService : IEmployeeRelatedService
    {
        private IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public EmployeeRelatedService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<EmployeeInExamSessionDto> GetDetailSessionOfEmployeeInExam([Required] int empId, [Required] int examId)
        {
            EmployeeInExamSessionDto result = null;
            IEnumerable<EmployeeRelated> allDetails = await _uow.EmployeeRelatedRepository.Get(filter: el => el.EmpId == empId, includeProperties: "ExamSession.Room,ExamSession.ExamGroup");
            IEnumerable<EmployeeRelated> details = (from el in allDetails where el.ExamSession.ExamGroup.ExamId == examId select el).ToList();
            if (details != null)
            {
                IEnumerable<EmployeeRelatedDto> detailsDto = _mapper.Map<IEnumerable<EmployeeRelatedDto>>(details);
                result = new EmployeeInExamSessionDto();
                result.EmpId = empId;
                foreach(EmployeeRelatedDto dto in detailsDto)
                {
                    result.ListExamSession.Add(dto.ExamSession);
                }
            }
            return result;
        }

    }
}
