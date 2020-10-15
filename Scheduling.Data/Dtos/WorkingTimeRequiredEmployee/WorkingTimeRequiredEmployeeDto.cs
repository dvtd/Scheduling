using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos.WorkingTimeRequiredEmployee
{
    public class WorkingTimeRequiredEmployeeDto : BaseDto
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? ExamId { get; set; }
        public int? MinHour { get; set; }
        public int? MaxHour { get; set; }

    }
}
