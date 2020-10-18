using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Bussiness.Service.ExamCourseService;
using Scheduling.Bussiness.Service.ExamService;
using Scheduling.Data.Dtos;
using Scheduling.Data.Dtos.Course;
using Scheduling.Data.Dtos.Exam;
using Scheduling.Data.Helper;

namespace SchedulingProject.Controller
{
    [Route("api/v1/exam")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }


        #region CRUD
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PagingRequestParam param)
        {
            var result = await _examService.GetAsync(pageIndex: param.PageIndex, pageSize: param.PageSize);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _examService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ExamDto dto)
        {
            var result = await _examService.CreateAsync(dto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ExamDto dto)
        {
            var result = await _examService.UpdateAsync(dto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("status")]
        public async Task<IActionResult> Delete([FromBody] ExamDto dto)
        {
            // chang status of dto to delete status
            dto.Status = 2;
            // update to table
            var result = await _examService.UpdateAsync(dto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        #endregion
    }
}
