using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Data.Models
{
    public partial class Course
    {
        public Course()
        {
            ExamCourse = new HashSet<ExamCourse>();
            StudentGroup = new HashSet<StudentGroup>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Column("SubjectID")]
        public int? SubjectId { get; set; }
        [Column("SemesterID")]
        public int? SemesterId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }
        [StringLength(255)]
        public string CreatePerson { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }
        [StringLength(255)]
        public string UpdatePerson { get; set; }
        public int? NumberOfStudents { get; set; }

        [ForeignKey(nameof(SemesterId))]
        [InverseProperty("Course")]
        public virtual Semester Semester { get; set; }
        [ForeignKey(nameof(SubjectId))]
        [InverseProperty("Course")]
        public virtual Subject Subject { get; set; }
        [InverseProperty("Course")]
        public virtual ICollection<ExamCourse> ExamCourse { get; set; }
        [InverseProperty("Course")]
        public virtual ICollection<StudentGroup> StudentGroup { get; set; }
    }
}
