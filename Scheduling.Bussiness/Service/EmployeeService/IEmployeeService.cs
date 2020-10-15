using Scheduling.Data.Dtos.Employee;
using Scheduling.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Bussiness.Service.EmployeeService
{
    public interface IEmployeeService : IBaseService<Employee,EmployeeDto>
    {
        public Task<bool> UpdateDelFlgEmployee(int id);
    }
}
