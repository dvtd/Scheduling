using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Data.Models
{
    public partial class ExamGroup
    {
        public ExamGroup()
        {
            ExamSession = new HashSet<ExamSession>();
            Register = new HashSet<Register>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExamGroupBegin { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExamGroupEnd { get; set; }
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

        [ForeignKey(nameof(ExamId))]
        [InverseProperty("ExamGroup")]
        public virtual Exam Exam { get; set; }
        [InverseProperty("ExamGroup")]
        public virtual ICollection<ExamSession> ExamSession { get; set; }
        [InverseProperty("ExamGroup")]
        public virtual ICollection<Register> Register { get; set; }
    }
}
