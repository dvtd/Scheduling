using Scheduling.Data.Dtos.Course;
using Scheduling.Data.Dtos.Exam;
using Scheduling.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Bussiness.Service.ExamService
{
    public interface IExamService :   IBaseService<Exam, ExamDto>
    {
    }
}
