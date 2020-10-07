using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos.Course
{
    public class CourseDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? SubjectId { get; set; }
        public int? SemesterId { get; set; }
    }
}
