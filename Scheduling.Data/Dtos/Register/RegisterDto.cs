using Scheduling.Data.Dtos.ExamGroup;
using Scheduling.Data.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos.Register
{
    public class RegisterDto : BaseDto
    {
        public RegisterDto()
        {
            ListExamGroup = new List<ExamGroupDto>();
        }
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? ExamId { get; set; }
        public int? ExamGroupId { get; set; }
        public int? Value { get; set; }
        public int LevelFlg { get; set; }
        public string Description { get; set; }
        public List<ExamGroupDto> ListExamGroup { get; set; }
        public virtual ExamGroupDto ExamGroup { get; set; }
    }
}
