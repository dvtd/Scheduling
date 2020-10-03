using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Bussiness.Service.ExamCourseService;
using Scheduling.Data.Dtos;
using Scheduling.Data.Dtos.Exam.ExamCourse;

namespace SchedulingProject.Controller
{
    [Route("api/v1/exam-course")]
    [ApiController]
    public class ExamCourseController : ControllerBase
    {
        private readonly IExamCourseService _examCourseService;

        public ExamCourseController(IExamCourseService examCourseService)
        {
            _examCourseService = examCourseService;
        }

        #region CRUD
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PagingRequestParam param)
        {
            var result = await _examCourseService.GetAsync(pageIndex: param.PageIndex, pageSize: param.PageSize);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _examCourseService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ExamCourseDto dto)
        {
            var result = await _examCourseService.CreateAsync(dto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ExamCourseDto dto)
        {
            var result = await _examCourseService.UpdateAsync(dto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete([FromRoute] int id)
        //{
        //    var result = await _examCourseService.DeleteAsync(id);
        //    return Ok(result);
        //}
        #endregion

    }
}

