using Scheduling.Data.Dtos.Course;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos.Major.Subject
{
   public  class SubjectDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? MajorId { get; set; }
        public virtual ICollection<CourseDto> Course { get; set; }

    }
}
