using AutoMapper;
using Scheduling.Data.Dtos.ExamGroup;
using Scheduling.Data.Models;
using Scheduling.Data.Repository;
using Scheduling.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Bussiness.Service.ExamGroupService
{
    public class ExamGroupService : BaseService<ExamGroup, ExamGroupDto>, IExamGroupService
    {
        public ExamGroupService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override IGenericRepository<ExamGroup> _reponsitory => _unitOfWork.ExamGroupRepository;
    }
}
