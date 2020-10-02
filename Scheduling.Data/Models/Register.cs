using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Data.Models
{
    public partial class Register
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("EmpID")]
        public int? EmpId { get; set; }
        [Column("ExamGroupID")]
        public int? ExamGroupId { get; set; }
        public int? Value { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }

        [ForeignKey(nameof(EmpId))]
        [InverseProperty(nameof(Employee.Register))]
        public virtual Employee Emp { get; set; }
        [ForeignKey(nameof(ExamGroupId))]
        [InverseProperty("Register")]
        public virtual ExamGroup ExamGroup { get; set; }
    }
}
