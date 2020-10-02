using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Data.Models
{
    public partial class EmployeeRelated
    {
        [Key]
        [Column("EmployeeRelatedID")]
        public int EmployeeRelatedId { get; set; }
        [Column("EmpID")]
        public int? EmpId { get; set; }
        [StringLength(255)]
        public string EmployeeFullname { get; set; }
        [Column("ExamSessionID")]
        public int? ExamSessionId { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        public int? Type { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }
        [StringLength(255)]
        public string CreatePerson { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }
        [StringLength(255)]
        public string UpdatePerson { get; set; }

        [ForeignKey(nameof(EmpId))]
        [InverseProperty(nameof(Employee.EmployeeRelated))]
        public virtual Employee Emp { get; set; }
        [ForeignKey(nameof(ExamSessionId))]
        [InverseProperty("EmployeeRelated")]
        public virtual ExamSession ExamSession { get; set; }
    }
}
