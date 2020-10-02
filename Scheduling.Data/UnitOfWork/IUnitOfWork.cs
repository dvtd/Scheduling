using Scheduling.Data.Models;
using Scheduling.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Semester> SemesterRepository { get; }

        Task<int> SaveAsync();
    }
}
