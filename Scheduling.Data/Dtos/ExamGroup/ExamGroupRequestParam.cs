using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos.ExamGroup
{
    public class ExamGroupRequestParam : PagingRequestParam
    {
        public int ExamId { get; set; }
    }
}
