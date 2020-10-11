using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Data.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeDevice = new HashSet<EmployeeDevice>();
            EmployeeRelated = new HashSet<EmployeeRelated>();
            Register = new HashSet<Register>();
            Semester = new HashSet<Semester>();
            WorkingTimeRequiredEmployee = new HashSet<WorkingTimeRequiredEmployee>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(255)]
        public string Username { get; set; }
        [StringLength(255)]
        public string Fullname { get; set; }
        [StringLength(255)]
        public string Phone { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }
        [StringLength(255)]
        public string UpdatePerson { get; set; }
        [Column("DepartmentID")]
        public int? DepartmentId { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Column("RoleID")]
        public int? RoleId { get; set; }
        public string Photo { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Employee")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty("Employee")]
        public virtual Role Role { get; set; }
        [InverseProperty("Emp")]
        public virtual ICollection<EmployeeDevice> EmployeeDevice { get; set; }
        [InverseProperty("Emp")]
        public virtual ICollection<EmployeeRelated> EmployeeRelated { get; set; }
        [InverseProperty("Emp")]
        public virtual ICollection<Register> Register { get; set; }
        [InverseProperty("Emp")]
        public virtual ICollection<Semester> Semester { get; set; }
        [InverseProperty("Emp")]
        public virtual ICollection<WorkingTimeRequiredEmployee> WorkingTimeRequiredEmployee { get; set; }
    }
}
