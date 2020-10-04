using Scheduling.Data.Models;
using Scheduling.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            InitRepository();
        }

        private bool _disposed = false;
        public IGenericRepository<Semester> SemesterRepository { get; set; }

        public IGenericRepository<Major> MajorRepository { get; set; }

        public IGenericRepository<Subject> SubjectRepository { get; set; }

        public IGenericRepository<Course> CourseRepository { get; set; }

        public IGenericRepository<Exam> ExamRepository { get; set; }

        public IGenericRepository<ExamCourse> ExamCourseRepository { get; set; }

        public IGenericRepository<ExamGroup> ExamGroupRepository { get; set; }

        public IGenericRepository<Employee> EmployeeRepository { get; set; }

        private void InitRepository()
        {
            SemesterRepository = new GenericRepository<Semester>(_context);
            MajorRepository = new GenericRepository<Major>(_context);
            SubjectRepository = new GenericRepository<Subject>(_context);
            CourseRepository = new GenericRepository<Course>(_context);
            ExamRepository = new GenericRepository<Exam>(_context);
            ExamCourseRepository = new GenericRepository<ExamCourse>(_context);
            ExamGroupRepository = new GenericRepository<ExamGroup>(_context);
            EmployeeRepository = new GenericRepository<Employee>(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
