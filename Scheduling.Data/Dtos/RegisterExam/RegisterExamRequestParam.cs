using Scheduling.Data.Dtos.RegisterExam.SubjectInExam;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos.RegisterExam
{
    public class RegisterExamRequestParam
    {
        public int ExamId { get; set; }
        public int SemesterId { get; set; }
        public int EmployeeId { get; set; }
        public List<SubjectInExamRequestParam> ListSubjectInExam { get; set; }
    }
}
