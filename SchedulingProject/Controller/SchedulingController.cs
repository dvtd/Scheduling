using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Bussiness.Service.EmployeeService;
using Scheduling.Bussiness.Service.FCM;
using Scheduling.Bussiness.Service.SchedulingService;

namespace SchedulingProject.Controller
{
    [Route("api/v1/scheduling-employee")]
    [ApiController]
    public class SchedulingController : ControllerBase
    {
        private readonly ISchedulingService _schedulingService;
        private readonly IEmployeeService _employeeService;
        private readonly IFCMService _fcmService;

        public SchedulingController(ISchedulingService schedulingService, IEmployeeService employeeService, IFCMService fcmService)
        {
            _schedulingService = schedulingService;
            _employeeService = employeeService;
            _fcmService = fcmService;
        }

        [HttpGet("exam/{examId}/{adminId}")]
        public async Task<IActionResult> SchedulingEmployee([FromRoute] int examId , int adminId)
        {
            try
            {
                var result = await _schedulingService.ScheduleEmployee(examId,adminId);
                if (result)
                {
                    var listEmp = await _employeeService.GetAsync();
                    foreach (var emp in listEmp)
                    {
                        string title = "Register Success";
                        string body = "Hi " + emp.Email + " Your schedule is registerd.";
                        await _fcmService.SendMessage(emp.Id, title, body);
                    }
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
