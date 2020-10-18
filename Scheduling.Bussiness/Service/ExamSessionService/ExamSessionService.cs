using AutoMapper;
using Scheduling.Data.Dtos.ExamSession;
using Scheduling.Data.Models;
using Scheduling.Data.Repository;
using Scheduling.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Bussiness.Service.ExamSessionService
{
    public class ExamSessionService : BaseService<ExamSession, ExamSessionDto>, IExamSessionService
    {
        public ExamSessionService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override IGenericRepository<ExamSession> _reponsitory => _unitOfWork.ExamSessionRepository;

    }
}
