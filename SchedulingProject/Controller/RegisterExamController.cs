using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Bussiness.Service.EmployeeService;
using Scheduling.Bussiness.Service.FCM;
using Scheduling.Bussiness.Service.RegisterExamService;
using Scheduling.Data.Dtos.Employee;
using Scheduling.Data.Dtos.RegisterExam;

namespace SchedulingProject.Controller
{
    [Route("api/register-exam")]
    [ApiController]
    public class RegisterExamController : ControllerBase
    {
        private readonly IRegisterExamService _registerExamService;
        private readonly IEmployeeService _employeeService;
        private readonly IFCMService _fcmService;

        public RegisterExamController(IRegisterExamService registerExamService, IEmployeeService employeeService, IFCMService fcmService)
        {
            _registerExamService = registerExamService;
            _employeeService = employeeService;
            _fcmService = fcmService;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterExam(RegisterExamRequestParam param)
        {
            try
            {
                var result = await _registerExamService.RegisterExam(param.SemesterId, param.ExamId, param.ListSubjectInExam, param.EmployeeId);
                if (result)
                {
                    var listEmp = await _employeeService.GetAsync();
                    foreach(var emp in listEmp)
                    {
                        string title = "Register Exam Group";
                        string body = "Hi " + emp.Email + " You got a schedule to register .";
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
