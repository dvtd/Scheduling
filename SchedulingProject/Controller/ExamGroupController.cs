using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Bussiness.Service.ExamGroupService;
using Scheduling.Data.Dtos;
using Scheduling.Data.Dtos.Exam.ExamCourse;
using Scheduling.Data.Dtos.ExamGroup;

namespace SchedulingProject.Controller
{
    [Route("api/v1/exam-group")]
    [ApiController]
    public class ExamGroupController : ControllerBase
    {
        private readonly IExamGroupService _examGroupService;

        public ExamGroupController(IExamGroupService examGroupService)
        {
            _examGroupService = examGroupService;
        }

        #region CRUD
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PagingRequestParam param)
        {
            var result = await _examGroupService.GetAsync(pageIndex: param.PageIndex, pageSize: param.PageSize);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _examGroupService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ExamGroupDto dto)
        {
            var result = await _examGroupService.CreateAsync(dto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ExamGroupDto dto)
        {
            var result = await _examGroupService.UpdateAsync(dto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete([FromRoute] int id)
        //{
        //    var result = await _examGroupService.DeleteAsync(id);
        //    return Ok(result);
        //}
        #endregion

    }
}
