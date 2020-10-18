using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Bussiness.Service.EmployeeRelatedService;
using Scheduling.Data.Dtos.EmployeeRalated;

namespace SchedulingProject.Controller
{
    [Route("api/v1/employee-related")]
    [ApiController]
    public class EmployeeRelatedController : ControllerBase
    {
        private readonly IEmployeeRelatedService _employeeRelatedService;

        public EmployeeRelatedController(IEmployeeRelatedService employeeRelatedService)
        {
            _employeeRelatedService = employeeRelatedService;
        }


        // get detail information of specific employee in exam session
        [HttpGet("detail-info-in-exam-session")]
        public async Task<IActionResult> GetDetail([FromQuery] EmployeeRelatedRequestParam param)
        {
            var result = await _employeeRelatedService.GetDetailSessionOfEmployeeInExam(param.EmpId, param.ExamId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
