using Scheduling.Data.Dtos.Role;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos.Employee
{
    public class EmployeeDto : BaseDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? DepartmentId { get; set; }
        public string Description { get; set; }
        public int? RoleId { get; set; }
        public int? DelFlg { get; set; }

        public RoleDto Role { get; set; }
    }
}
