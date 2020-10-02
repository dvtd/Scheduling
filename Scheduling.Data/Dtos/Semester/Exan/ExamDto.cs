using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos.Semester.Exan
{
   public class ExamDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? ExamBegin { get; set; }
        public DateTime? ExamEnd { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int? SemesterId { get; set; }

    }
}
