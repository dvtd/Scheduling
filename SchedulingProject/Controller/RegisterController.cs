using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Bussiness.Service.RegisterService;
using Scheduling.Data.Dtos;
using Scheduling.Data.Dtos.Register;

namespace SchedulingProject.Controller
{
    [Route("api/v1/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        #region CRUD
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RegisterRequestParam param)
        {
            var result = await _registerService.GetAsync(pageIndex: param.PageIndex, pageSize: param.PageSize,
                filter: el => el.EmpId == param.EmpId && el.ExamGroupId == param.ExamGroupId
                );
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _registerService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] RegisterDto dto)
        {
            var result = await _registerService.CreateAsync(dto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RegisterDto dto)
        {
            var result = await _registerService.UpdateAsync(dto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _registerService.DeleteAsync(id);
            return Ok(result);
        }
        #endregion
    }
}
