using AutoMapper;
using Scheduling.Data.Dtos.Course;
using Scheduling.Data.Models;
using Scheduling.Data.Repository;
using Scheduling.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Bussiness.Service.CourseService
{
    public class CourseService : BaseService<Course, CourseDto>, ICourseService
    {
        public CourseService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override IGenericRepository<Course> _reponsitory => _unitOfWork.CourseRepository;
    }
}
