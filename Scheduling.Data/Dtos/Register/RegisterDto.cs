using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos.Register
{
    public class RegisterDto : BaseDto
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? ExamGroupId { get; set; }
        public int? Value { get; set; }
        public string Description { get; set; }
    }
}
