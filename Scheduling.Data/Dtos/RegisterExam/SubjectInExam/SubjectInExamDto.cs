using Scheduling.Data.Dtos.ExamGroup;
using Scheduling.Data.Dtos.Major.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos.RegisterExam.SubjectInExam
{
   public class SubjectInExamDto
    {
       public SubjectDto Subject { get; set; }
        public ExamGroupDto ExamGroup { get;set; }
    }
}
