using AutoMapper;
using Scheduling.Data.Dtos.Semester;
using Scheduling.Data.Models;
using Scheduling.Data.Repository;
using Scheduling.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Bussiness.Service.SemesterService
{
    public class SemesterService : BaseService<Semester, SemesterDto>, ISemesterService
    {
        public SemesterService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override IGenericRepository<Semester> _reponsitory => _unitOfWork.SemesterRepository;
    }
}
