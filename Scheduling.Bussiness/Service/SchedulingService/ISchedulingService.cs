using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Bussiness.Service.SchedulingService
{
    public interface ISchedulingService
    {
        Task<bool> ScheduleEmployee(int exampId, int adminId);
    }
}
