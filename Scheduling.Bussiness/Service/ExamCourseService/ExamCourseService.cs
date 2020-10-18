using AutoMapper;
using Scheduling.Data.Dtos.Course;
using Scheduling.Data.Dtos.Exam.ExamCourse;
using Scheduling.Data.Models;
using Scheduling.Data.Repository;
using Scheduling.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Bussiness.Service.ExamCourseService
{
    public class ExamCourseService : BaseService<ExamCourse, ExamCourseDto>, IExamCourseService
    {
        public ExamCourseService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override IGenericRepository<ExamCourse> _reponsitory => _unitOfWork.ExamCourseRepository;
    }
}
