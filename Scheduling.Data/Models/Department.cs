using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Data.Models
{
    public partial class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
            WorkingTimeRequiredDepartment = new HashSet<WorkingTimeRequiredDepartment>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(255)]
        public string DepartmentName { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<Employee> Employee { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<WorkingTimeRequiredDepartment> WorkingTimeRequiredDepartment { get; set; }
    }
}
