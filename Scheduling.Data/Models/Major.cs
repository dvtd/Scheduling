using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Data.Models
{
    public partial class Major
    {
        public Major()
        {
            Subject = new HashSet<Subject>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }

        [InverseProperty("Major")]
        public virtual ICollection<Subject> Subject { get; set; }
    }
}
