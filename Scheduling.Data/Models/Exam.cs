using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Data.Models
{
    public partial class Exam
    {
        public Exam()
        {
            ExamCourse = new HashSet<ExamCourse>();
            ExamGroup = new HashSet<ExamGroup>();
            WorkingTimeRequiredDepartment = new HashSet<WorkingTimeRequiredDepartment>();
            WorkingTimeRequiredEmployee = new HashSet<WorkingTimeRequiredEmployee>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExamBegin { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExamEnd { get; set; }
        [StringLength(255)]
        public string Type { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }
        [StringLength(255)]
        public string CreatePerson { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }
        [StringLength(255)]
        public string UpdatePerson { get; set; }
        [Column("SemesterID")]
        public int? SemesterId { get; set; }
        public int? Status { get; set; }

        [ForeignKey(nameof(SemesterId))]
        [InverseProperty("Exam")]
        public virtual Semester Semester { get; set; }
        [InverseProperty("Exam")]
        public virtual ICollection<ExamCourse> ExamCourse { get; set; }
        [InverseProperty("Exam")]
        public virtual ICollection<ExamGroup> ExamGroup { get; set; }
        [InverseProperty("Exam")]
        public virtual ICollection<WorkingTimeRequiredDepartment> WorkingTimeRequiredDepartment { get; set; }
        [InverseProperty("Exam")]
        public virtual ICollection<WorkingTimeRequiredEmployee> WorkingTimeRequiredEmployee { get; set; }
    }
}
