using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos.ExamGroup
{
    public class ExamGroupDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ExamId { get; set; }
        public TimeSpan? TimeBegin { get; set; }
        public TimeSpan? TimeEnd { get; set; }
        public DateTime? ExamDate { get; set; }
    }
}
