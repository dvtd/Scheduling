using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Data.Models
{
    public partial class Role
    {
        public Role()
        {
            Employee = new HashSet<Employee>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("Role")]
        [StringLength(255)]
        public string Role1 { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
