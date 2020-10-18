using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Bussiness.Service.SubjectService;
using Scheduling.Data.Dtos;
using Scheduling.Data.Dtos.Major.Subject;

namespace SchedulingProject.Controller
{
    [Route("api/v1/subject")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        #region CRUD
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PagingRequestParam param)
        {
            var result = await _subjectService.GetAsync(pageIndex: param.PageIndex, pageSize: param.PageSize);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _subjectService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] SubjectDto dto)
        {
            var result = await _subjectService.CreateAsync(dto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SubjectDto dto)
        {
            var result = await _subjectService.UpdateAsync(dto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        #endregion

        [HttpGet("{id}/courses")]
        public async Task<IActionResult> GetCoursesById([FromRoute] int id)
        {
            var result = await _subjectService.GetAsync(filter: el => el.Id == id, includeProperties: "Course");
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
