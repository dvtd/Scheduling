using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Data.Models
{
    public partial class StudentGroup
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public int? NumberOfStudent { get; set; }
        [Column("CourseID")]
        public int? CourseId { get; set; }
        [Column("ExamSessionID")]
        public int? ExamSessionId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }
        [StringLength(255)]
        public string CreatePerson { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }
        [StringLength(255)]
        public string UpdatePerson { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty("StudentGroup")]
        public virtual Course Course { get; set; }
        [ForeignKey(nameof(ExamSessionId))]
        [InverseProperty("StudentGroup")]
        public virtual ExamSession ExamSession { get; set; }
    }
}
