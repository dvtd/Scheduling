using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Bussiness.Cache;
using Scheduling.Bussiness.Service.MajorService;
using Scheduling.Data.Dtos;
using Scheduling.Data.Dtos.Major;
using Scheduling.Data.Helper;

namespace SchedulingProject.Controller
{
    [Route("api/v1/major")]
    [ApiController]
    public class MajorController : ControllerBase
    {
        private readonly IMajorService _majorService;

        public MajorController(IMajorService majorService)
        {
            _majorService = majorService;
        }
       

        #region CRUD
        [HttpGet]
        [Cached(600)]
        public async Task<IActionResult> Get([FromQuery] PagingRequestParam param)
        {
            var result = await _majorService.GetAsync(pageIndex: param.PageIndex, pageSize: param.PageSize);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _majorService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [CacheClearing]
        public async Task<IActionResult> Insert([FromBody] MajorDto dto)
        {
            var result = await _majorService.CreateAsync(dto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MajorDto dto)
        {
            var result = await _majorService.UpdateAsync(dto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        #endregion

        [HttpGet("{id}/subjects")]
        public async Task<IActionResult> GetSubjectsById([FromRoute] int id)
        {
            var result = await _majorService.GetAsync(filter: el => el.Id == id, includeProperties: "Subject");
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }

}
