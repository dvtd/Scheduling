using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Data.Models
{
    public partial class Semester
    {
        public Semester()
        {
            Course = new HashSet<Course>();
            Exam = new HashSet<Exam>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(255)]
        public string SemesterName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SemesterBegin { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SemesterEnd { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }
        [StringLength(255)]
        public string UpdatePerson { get; set; }
        [Column("EmpID")]
        public int? EmpId { get; set; }

        [ForeignKey(nameof(EmpId))]
        [InverseProperty(nameof(Employee.Semester))]
        public virtual Employee Emp { get; set; }
        [InverseProperty("Semester")]
        public virtual ICollection<Course> Course { get; set; }
        [InverseProperty("Semester")]
        public virtual ICollection<Exam> Exam { get; set; }
    }
}
