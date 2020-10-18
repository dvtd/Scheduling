using Scheduling.Data.Dtos.Employee;
using Scheduling.Data.Dtos.Course;
using System;
using System.Collections.Generic;
using System.Text;
using Scheduling.Data.Dtos.Exam;

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

        public virtual ICollection<ExamDto> Exam { get; set; }


    }
}
