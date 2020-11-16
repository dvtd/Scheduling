using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Data.Models
{
    public partial class ExamSession
    {
        public ExamSession()
        {
            EmployeeRelated = new HashSet<EmployeeRelated>();
            StudentGroup = new HashSet<StudentGroup>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("RoomID")]
        public int? RoomId { get; set; }
        [StringLength(255)]
        public string RoomName { get; set; }
        [Column("ExamGroupID")]
        public int? ExamGroupId { get; set; }
        [StringLength(255)]
        public string ExamGroupName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }
        [StringLength(255)]
        public string CreatePerson { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }
        [StringLength(255)]
        public string UpdatePerson { get; set; }
        public int? Status { get; set; }
        public int? SubjectId { get; set; }

        [ForeignKey(nameof(ExamGroupId))]
        [InverseProperty("ExamSession")]
        public virtual ExamGroup ExamGroup { get; set; }
        [ForeignKey(nameof(RoomId))]
        [InverseProperty("ExamSession")]
        public virtual Room Room { get; set; }
        [ForeignKey(nameof(SubjectId))]
        [InverseProperty("ExamSession")]
        public virtual Subject Subject { get; set; }
        [InverseProperty("ExamSession")]
        public virtual ICollection<EmployeeRelated> EmployeeRelated { get; set; }
        [InverseProperty("ExamSession")]
        public virtual ICollection<StudentGroup> StudentGroup { get; set; }
    }
}
