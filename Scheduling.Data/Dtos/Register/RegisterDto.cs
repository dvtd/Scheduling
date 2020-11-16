using Scheduling.Data.Dtos.Employee;
using Scheduling.Data.Dtos.ExamGroup;
using Scheduling.Data.Helper;
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
        public int? Status { get; set; }

        public string Description { get; set; }
        public int? UpdateAdminId { get; set; }

        public virtual EmployeeDto Emp { get; set; }
        public virtual ExamGroupDto ExamGroup { get; set; }
    }
}
