using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos.Exam.ExamCourse
{
    public class ExamCourseDto : BaseDto
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? ExamId { get; set; }
        public int? NumberOfStudent { get; set; }
    }
}
