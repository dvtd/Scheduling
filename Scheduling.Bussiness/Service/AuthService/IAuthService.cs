using FirebaseAdmin.Auth;
using Scheduling.Data.Dtos.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Bussiness.Service.AuthService
{
    public interface IAuthService
    {
        public Task<EmployeeDto> Login(FirebaseToken userToken);
    }
}
