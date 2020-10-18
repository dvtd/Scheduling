using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Bussiness.Service.RegisterExamService;
using Scheduling.Data.Dtos.RegisterExam;

namespace SchedulingProject.Controller
{
    [Route("api/register-exam")]
    [ApiController]
    public class RegisterExamController : ControllerBase
    {
        private readonly IRegisterExamService _registerExamService;

        public RegisterExamController(IRegisterExamService registerExamService)
        {
            _registerExamService = registerExamService;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterExam(RegisterExamRequestParam param)
        {
            try
            {
                var result = await _registerExamService.RegisterExam(param.SemesterId, param.ExamId, param.ListSubjectInExam, param.EmployeeId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
