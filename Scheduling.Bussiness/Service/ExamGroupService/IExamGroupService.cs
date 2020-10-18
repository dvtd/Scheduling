using Scheduling.Data.Dtos.ExamGroup;
using Scheduling.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Bussiness.Service.ExamGroupService
{
    public interface IExamGroupService :  IBaseService<ExamGroup, ExamGroupDto>
    {
        public Task<IEnumerable<ExamGroup>> GetListExamGroupForRegistering(int examId);
    }
}
