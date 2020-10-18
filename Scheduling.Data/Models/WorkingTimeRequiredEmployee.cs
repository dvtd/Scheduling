using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Data.Models
{
    public partial class WorkingTimeRequiredEmployee
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("EmpID")]
        public int? EmpId { get; set; }
        [Column("ExamID")]
        public int? ExamId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }
        [StringLength(255)]
        public string CreatePerson { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }
        [StringLength(255)]
        public string UpdatePerson { get; set; }
        public int? MinHour { get; set; }
        public int? MaxHour { get; set; }

        [ForeignKey(nameof(EmpId))]
        [InverseProperty(nameof(Employee.WorkingTimeRequiredEmployee))]
        public virtual Employee Emp { get; set; }
        [ForeignKey(nameof(ExamId))]
        [InverseProperty("WorkingTimeRequiredEmployee")]
        public virtual Exam Exam { get; set; }
    }
}
