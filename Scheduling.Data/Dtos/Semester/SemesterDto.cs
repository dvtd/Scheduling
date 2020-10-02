using Scheduling.Data.Dtos.Employee;
using Scheduling.Data.Dtos.Semester.Course;
using Scheduling.Data.Dtos.Semester.Exan;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos.Semester
{
   public class SemesterDto : BaseDto
    {
        public int? Id { get; set; }
        public string SemesterName { get; set; }
        public DateTime? SemesterBegin { get; set; }
        public DateTime? SemesterEnd { get; set; }
        public string Description { get; set; }
        public int? EmpId { get; set; }

        //public  EmployeeDto? Emp { get; set; }
        //public  List<CourseDto>? Course { get; set; }
        //public List<ExamDto>? Exam { get; set; }

    }
}
