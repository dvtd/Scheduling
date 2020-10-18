using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Bussiness.Service.CourseService;
using Scheduling.Data.Dtos.Course;

namespace SchedulingProject.Controller
{
    [Route("api/v1/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("get-all-by-subject-and-semester")]
        public async Task<IActionResult> Get([FromQuery] CourseRequestParam param)
        {
            var result = await _courseService.GetAsync(filter: el => el.SemesterId == param.idSemester && el.SubjectId == param.idSubject);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
