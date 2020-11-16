using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Data.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Course = new HashSet<Course>();
            ExamSession = new HashSet<ExamSession>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Column("MajorID")]
        public int? MajorId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }
        [StringLength(255)]
        public string CreatePerson { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }
        [StringLength(255)]
        public string UpdatePerson { get; set; }

        [ForeignKey(nameof(MajorId))]
        [InverseProperty("Subject")]
        public virtual Major Major { get; set; }
        [InverseProperty("Subject")]
        public virtual ICollection<Course> Course { get; set; }
        [InverseProperty("Subject")]
        public virtual ICollection<ExamSession> ExamSession { get; set; }
    }
}
