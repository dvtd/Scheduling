using AutoMapper;
using Scheduling.Data.Dtos.Exam;
using Scheduling.Data.Models;
using Scheduling.Data.Repository;
using Scheduling.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Bussiness.Service.ExamService
{
    public class ExamService : BaseService<Exam, ExamDto>, IExamService
    {
        public ExamService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override IGenericRepository<Exam> _reponsitory => _unitOfWork.ExamRepository;
    }
}
