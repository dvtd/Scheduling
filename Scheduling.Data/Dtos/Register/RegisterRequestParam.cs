using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos.Register
{
   public class RegisterRequestParam : PagingRequestParam
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public int ExamGroupId { get; set; }
    }
}
