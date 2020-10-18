using AutoMapper;
using Scheduling.Bussiness.Service.WorkingTimeRequiredEmployeeService;
using Scheduling.Data.Dtos.WorkingTimeRequiredEmployee;
using Scheduling.Data.Models;
using Scheduling.Data.Repository;
using Scheduling.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Bussiness.Service.WorkingTimeRequiredEmployeeService
{
    public class WorkingTimeRequiredEmployeeService : BaseService<WorkingTimeRequiredEmployee, WorkingTimeRequiredEmployeeDto>, IWorkingTimeRequiredEmployeeService
    {
        public WorkingTimeRequiredEmployeeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override IGenericRepository<WorkingTimeRequiredEmployee> _reponsitory => _unitOfWork.WorkingTimeRequiredEmployeeRepository;
    }
}
