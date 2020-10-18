using Scheduling.Data.Dtos.WorkingTimeRequiredEmployee;
using Scheduling.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Bussiness.Service.WorkingTimeRequiredEmployeeService
{
    public interface IWorkingTimeRequiredEmployeeService : IBaseService<WorkingTimeRequiredEmployee, WorkingTimeRequiredEmployeeDto>
    {
    }
}
