using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Bussiness.Service.WorkingTimeRequiredEmployeeService;
using Scheduling.Data.Dtos.WorkingTimeRequiredEmployee;

namespace SchedulingProject.Controller
{
    [Route("api/v1/employee-constraint")]
    [ApiController]
    public class EmployeeConstraintTimeController : ControllerBase
    {
        private readonly IWorkingTimeRequiredEmployeeService _workingTimeRequiredEmployeeService;

        public EmployeeConstraintTimeController(IWorkingTimeRequiredEmployeeService workingTimeRequiredEmployeeService)
        {
            _workingTimeRequiredEmployeeService = workingTimeRequiredEmployeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(EmployeeConstraintRequestParam param)
        {
            var result = await _workingTimeRequiredEmployeeService.GetAsync(filter: el => el.ExamId == param.ExamId && el.EmpId == param.EmpId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
