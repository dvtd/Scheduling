using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Bussiness.Service.FCM;
using Scheduling.Data.Dtos.Employee;

namespace SchedulingProject.Controller
{
    [Route("api/v1/fcm")]
    [ApiController]
    public class FCMController : ControllerBase
    {
        private readonly IFCMService _fCMService;

        public FCMController(IFCMService fCMService)
        {
            _fCMService = fCMService;
        }

        [HttpPost("check-devide-employee")]
        public async Task<IActionResult> Get([FromQuery] DeviceDto param)
        {
            if (await _fCMService.CheckDevice(param.EmpId, param.DeviceId))
            {
                return StatusCode(201);
            }
            return BadRequest();
        }
    }
}
