using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Data.Models
{
    public partial class ExamCourse
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("CourseID")]
        public int? CourseId { get; set; }
        [Column("ExamID")]
        public int? ExamId { get; set; }
        public int? NumberOfStudent { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }
        [StringLength(255)]
        public string CreatePerson { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }
        [StringLength(255)]
        public string UpdatePerson { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty("ExamCourse")]
        public virtual Course Course { get; set; }
        [ForeignKey(nameof(ExamId))]
        [InverseProperty("ExamCourse")]
        public virtual Exam Exam { get; set; }
    }
}
