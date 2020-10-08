using AutoMapper;
using Scheduling.Data.Dtos.Register;
using Scheduling.Data.Models;
using Scheduling.Data.Repository;
using Scheduling.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Bussiness.Service.RegisterService
{
    public class RegisterService : BaseService<Register, RegisterDto>, IRegisterService
    {
        public RegisterService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override IGenericRepository<Register> _reponsitory => _unitOfWork.RegisterRepository;
    }
}
