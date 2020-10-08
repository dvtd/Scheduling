using AutoMapper;
using Scheduling.Data.Dtos.Major;
using Scheduling.Data.Models;
using Scheduling.Data.Repository;
using Scheduling.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Bussiness.Service.MajorService
{
    public class MajorService : BaseService<Major, MajorDto>, IMajorService
    {
        public MajorService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override IGenericRepository<Major> _reponsitory => _unitOfWork.MajorRepository;
    }
}
