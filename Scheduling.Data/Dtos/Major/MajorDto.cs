using Scheduling.Data.Dtos.Major.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos.Major
{
    public class MajorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<SubjectDto> Subject { get; set; }
    }
}
