using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Data.Models
{
    public partial class EmployeeDevice
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("EmpID")]
        public int? EmpId { get; set; }
        [StringLength(255)]
        public string DeviceId { get; set; }

        [ForeignKey(nameof(EmpId))]
        [InverseProperty(nameof(Employee.EmployeeDevice))]
        public virtual Employee Emp { get; set; }
    }
}
