using AutoMapper;
using Scheduling.Data.Dtos.Major.Subject;
using Scheduling.Data.Models;
using Scheduling.Data.Repository;
using Scheduling.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Bussiness.Service.SubjectService
{
    public class SubjectService : BaseService<Subject, SubjectDto>, ISubjectService
    {
        public SubjectService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override IGenericRepository<Subject> _reponsitory => _unitOfWork.SubjectRepository;
    }
}
