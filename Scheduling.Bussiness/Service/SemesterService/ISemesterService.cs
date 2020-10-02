using Scheduling.Data.Dtos.Semester;
using Scheduling.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Bussiness.Service.SemesterService
{
    public interface ISemesterService : IBaseService<Semester,SemesterDto>
    {
    }
}
