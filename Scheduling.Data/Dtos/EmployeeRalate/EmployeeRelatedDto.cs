using Scheduling.Data.Dtos.ExamSession;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos.EmployeeRalate
{
    public class EmployeeRelatedDto : BaseDto
    {
        public int EmployeeRelatedId { get; set; }
        public int? EmpId { get; set; }
        public string EmployeeFullname { get; set; }
        public int? ExamSessionId { get; set; }
        public string Status { get; set; }
        public int? Type { get; set; }
        public virtual ExamSessionDto ExamSession { get; set; }
    }
}

