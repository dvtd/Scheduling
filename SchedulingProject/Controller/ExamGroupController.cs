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

        // Return list exam group in exam so that employee can register the preferable in each exam group
        [HttpGet("employee-register-group")]
        public async Task<IActionResult> GetListExamGroupForRegitering([FromQuery] ExamGroupRequestParam param)
        {
            //var result = await _examGroupService.GetAsync(
            //                            pageIndex: param.PageIndex,
            //                            pageSize: param.PageSize,
            //                            filter: el => el.ExamId == param.ExamId,
            //                            orderBy: el => el.OrderBy(e => e.ExamDate).ThenBy(e => e.TimeBegin));
            var result = await _examGroupService.GetListExamGroupForRegistering(param.ExamId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
