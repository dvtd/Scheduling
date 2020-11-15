using Scheduling.Data.Dtos.EmployeeRalate;
using Scheduling.Data.Dtos.EmployeeRalated;
using Scheduling.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Bussiness.Service.EmployeeRelatedService
{
    public interface IEmployeeRelatedService 
    {
        public Task<EmployeeInExamSessionDto> GetDetailSessionOfEmployeeInExam([Required]int empId, [Required] int examId);

        public Task<IEnumerable<EmployeeRelatedDto>> GetAllEmployeeRelated(int examId);
    }
}
