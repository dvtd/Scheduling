using Scheduling.Data.Dtos.ExamGroup;
using Scheduling.Data.Dtos.Register;
using Scheduling.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Bussiness.Service.RegisterService
{
   public interface IRegisterService : IBaseService<Register, RegisterDto>
    {
        public Task<bool> RegisterExamGroup(List<RegisterDto> listRegister,int examId);

        public Task<IEnumerable<RegisterDto>> GetListRegisterByEmployee(int examId, int empId);
    }
}
