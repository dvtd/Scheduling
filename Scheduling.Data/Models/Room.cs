using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Data.Models
{
    public partial class Room
    {
        public Room()
        {
            ExamSession = new HashSet<ExamSession>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(255)]
        public string RoomName { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public int? RoomType { get; set; }

        [InverseProperty("Room")]
        public virtual ICollection<ExamSession> ExamSession { get; set; }
    }
}
