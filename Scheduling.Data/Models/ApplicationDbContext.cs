using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Scheduling.Data.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeDevice> EmployeeDevice { get; set; }
        public virtual DbSet<EmployeeRelated> EmployeeRelated { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<ExamCourse> ExamCourse { get; set; }
        public virtual DbSet<ExamGroup> ExamGroup { get; set; }
        public virtual DbSet<ExamSession> ExamSession { get; set; }
        public virtual DbSet<Major> Major { get; set; }
        public virtual DbSet<Register> Register { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Semester> Semester { get; set; }
        public virtual DbSet<StudentGroup> StudentGroup { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<WorkingTimeRequiredDepartment> WorkingTimeRequiredDepartment { get; set; }
        public virtual DbSet<WorkingTimeRequiredEmployee> WorkingTimeRequiredEmployee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=SE130120;Database=Scheduling;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("FK__Course__Semester__2B3F6F97");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__Course__SubjectI__2A4B4B5E");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Employee__Depart__145C0A3F");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Employee__RoleID__15502E78");
            });

            modelBuilder.Entity<EmployeeDevice>(entity =>
            {
                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmployeeDevice)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__EmployeeD__EmpID__182C9B23");
            });

            modelBuilder.Entity<EmployeeRelated>(entity =>
            {
                entity.Property(e => e.Status).IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmployeeRelated)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__EmployeeR__EmpID__35BCFE0A");

                entity.HasOne(d => d.ExamSession)
                    .WithMany(p => p.EmployeeRelated)
                    .HasForeignKey(d => d.ExamSessionId)
                    .HasConstraintName("FK__EmployeeR__ExamS__36B12243");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.Exam)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("FK__Exam__SemesterID__1DE57479");
            });

            modelBuilder.Entity<ExamCourse>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.ExamCourse)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__ExamCours__Cours__2E1BDC42");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.ExamCourse)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK__ExamCours__ExamI__2F10007B");
            });

            modelBuilder.Entity<ExamGroup>(entity =>
            {
                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.ExamGroup)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK__ExamGroup__ExamI__20C1E124");
            });

            modelBuilder.Entity<ExamSession>(entity =>
            {
                entity.HasOne(d => d.ExamGroup)
                    .WithMany(p => p.ExamSession)
                    .HasForeignKey(d => d.ExamGroupId)
                    .HasConstraintName("FK__ExamSessi__ExamG__32E0915F");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.ExamSession)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__ExamSessi__RoomI__31EC6D26");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Register)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__Register__EmpID__3D5E1FD2");

                entity.HasOne(d => d.ExamGroup)
                    .WithMany(p => p.Register)
                    .HasForeignKey(d => d.ExamGroupId)
                    .HasConstraintName("FK__Register__ExamGr__3E52440B");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Semester)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__Semester__EmpID__1B0907CE");
            });

            modelBuilder.Entity<StudentGroup>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentGroup)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__StudentGr__Cours__44FF419A");

                entity.HasOne(d => d.ExamSession)
                    .WithMany(p => p.StudentGroup)
                    .HasForeignKey(d => d.ExamSessionId)
                    .HasConstraintName("FK__StudentGr__ExamS__45F365D3");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.MajorId)
                    .HasConstraintName("FK__Subject__MajorID__276EDEB3");
            });

            modelBuilder.Entity<WorkingTimeRequiredDepartment>(entity =>
            {
                entity.HasOne(d => d.Department)
                    .WithMany(p => p.WorkingTimeRequiredDepartment)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__WorkingTi__Depar__412EB0B6");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.WorkingTimeRequiredDepartment)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK__WorkingTi__ExamI__4222D4EF");
            });

            modelBuilder.Entity<WorkingTimeRequiredEmployee>(entity =>
            {
                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.WorkingTimeRequiredEmployee)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__WorkingTi__EmpID__398D8EEE");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.WorkingTimeRequiredEmployee)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK__WorkingTi__ExamI__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
