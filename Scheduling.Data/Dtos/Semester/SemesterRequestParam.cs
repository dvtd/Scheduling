using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos.Semester
{
    public class SemesterRequestParam : BaseDto
    {
        public string SemesterName { get; set; }
        public DateTime? SemesterBegin { get; set; }
        public DateTime? SemesterEnd { get; set; }
        public string Description { get; set; }
        public int? EmpId { get; set; }

    }
}
