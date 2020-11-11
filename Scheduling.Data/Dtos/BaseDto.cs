using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos
{
   public class BaseDto
    {
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string CreatePerson { get; set; }
        public string UpdatePerson { get; set; }

    }
}
