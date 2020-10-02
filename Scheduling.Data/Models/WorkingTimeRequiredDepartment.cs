using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Data.Models
{
    public partial class WorkingTimeRequiredDepartment
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("DepartmentID")]
        public int? DepartmentId { get; set; }
        [Column("ExamID")]
        public int? ExamId { get; set; }
        public TimeSpan? MinHour { get; set; }
        public TimeSpan? MaxHour { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }
        [StringLength(255)]
        public string CreatePerson { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }
        [StringLength(255)]
        public string UpdatePerson { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("WorkingTimeRequiredDepartment")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(ExamId))]
        [InverseProperty("WorkingTimeRequiredDepartment")]
        public virtual Exam Exam { get; set; }
    }
}
