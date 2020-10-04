using Scheduling.Data.Models;
using Scheduling.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Semester> SemesterRepository { get; }
        IGenericRepository<Major> MajorRepository { get; }
        IGenericRepository<Subject> SubjectRepository { get; }
        IGenericRepository<Course> CourseRepository { get; }
        IGenericRepository<ExamCourse> ExamCourseRepository { get; }
        IGenericRepository<ExamGroup> ExamGroupRepository { get; }
        IGenericRepository<Exam> ExamRepository { get; }
        IGenericRepository<Employee> EmployeeRepository { get; }


        Task<int> SaveAsync();
    }
}
