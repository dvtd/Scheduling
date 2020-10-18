using Scheduling.Data.Dtos.RegisterExam.SubjectInExam;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Bussiness.Service.RegisterExamService
{
    public interface IRegisterExamService
    {
        Task<bool> RegisterExam([Required] int semester , [Required] int examId, [Required] List<SubjectInExamRequestParam> listSubjectInExam, [Required] int empId);
    }
}
