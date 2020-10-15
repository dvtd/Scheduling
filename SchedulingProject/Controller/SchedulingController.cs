using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Bussiness.Service.SchedulingService;

namespace SchedulingProject.Controller
{
    [Route("api/v1/scheduling-employee")]
    [ApiController]
    public class SchedulingController : ControllerBase
    {
        private readonly ISchedulingService _schedulingService;

        public SchedulingController(ISchedulingService schedulingService)
        {
            _schedulingService = schedulingService;
        }

        [HttpGet("exam/{examId}/{adminId}")]
        public async Task<IActionResult> SchedulingEmployee([FromRoute] int examId , int adminId)
        {
            try
            {
                var result = await _schedulingService.ScheduleEmployee(examId,adminId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
