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
        IGenericRepository<EmployeeDevice> DeviceRepository { get; }
        IGenericRepository<Register> RegisterRepository { get; }
        IGenericRepository<Room> RoomRepository { get; }
        IGenericRepository<ExamSession> ExamSessionRepository { get; }
        IGenericRepository<EmployeeRelated> EmployeeRelatedRepository { get; }
        IGenericRepository<WorkingTimeRequiredDepartment> WorkingTimeRequiredDepartmentRepository { get; }
        IGenericRepository<WorkingTimeRequiredEmployee> WorkingTimeRequiredEmployeeRepository { get; }
        IGenericRepository<Department> DepartmentRepository { get; }

        Task<int> SaveAsync();
    }
}
