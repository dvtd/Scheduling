using AutoMapper;
using Scheduling.Data.Dtos.Employee;
using Scheduling.Data.Models;
using Scheduling.Data.Repository;
using Scheduling.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Bussiness.Service.EmployeeService
{
    public class EmployeeService : BaseService<Employee, EmployeeDto>, IEmployeeService
    {
        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override IGenericRepository<Employee> _reponsitory => _unitOfWork.EmployeeRepository;

        public async Task<bool> UpdateDelFlgEmployee(int id)
        {
            var entity = await _unitOfWork.EmployeeRepository.GetById(id);
            if (entity != null)
            {
                entity.DelFlg = 1;
                _unitOfWork.EmployeeRepository.Update(entity);
            }
            return await _unitOfWork.SaveAsync() > 0 ;
        }
    }
}
