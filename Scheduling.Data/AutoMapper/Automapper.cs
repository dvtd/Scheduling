using AutoMapper;
using Scheduling.Data.Dtos.Employee;
using Scheduling.Data.Dtos.Exam;
using Scheduling.Data.Dtos.Semester;
using Scheduling.Data.Dtos.Course;
using Scheduling.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Scheduling.Data.Dtos.Exam.ExamCourse;
using Scheduling.Data.Dtos.ExamGroup;
using Scheduling.Data.Dtos.Role;
using Scheduling.Data.Dtos.Major;
using Scheduling.Data.Dtos.Major.Subject;
using Scheduling.Data.Dtos.Register;
using Scheduling.Data.Dtos.Room;
using Scheduling.Data.Dtos.ExamSession;
using Scheduling.Data.Dtos.EmployeeRalate;
using Scheduling.Data.Dtos.WorkingTimeRequiredEmployee;

namespace Scheduling.Data.AutoMapper
{
    class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();

            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();

            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();

            CreateMap<Exam, ExamDto>();
            CreateMap<ExamDto, Exam>();

            CreateMap<Semester, SemesterDto>();
            CreateMap<SemesterDto, Semester>();

            CreateMap<ExamCourse, ExamCourseDto>();
            CreateMap<ExamCourseDto, ExamCourse>();

            CreateMap<ExamGroup, ExamGroupDto>();
            CreateMap<ExamGroupDto, ExamGroup>();

            CreateMap<Major, MajorDto>();
            CreateMap<MajorDto, Major>();

            CreateMap<Subject, SubjectDto>();
            CreateMap<SubjectDto, Subject>();

            CreateMap<Register, RegisterDto>();
            CreateMap<RegisterDto, Register>();

            CreateMap<Room, RoomDto>();
            CreateMap<RoomDto, Room>();

            CreateMap<ExamSession, ExamSessionDto>();
            CreateMap<ExamSessionDto, ExamSession>();

            CreateMap<EmployeeRelated, EmployeeRelatedDto>();
            CreateMap<EmployeeRelatedDto, EmployeeRelated>();

            CreateMap<WorkingTimeRequiredEmployee, WorkingTimeRequiredEmployeeDto>();
            CreateMap<WorkingTimeRequiredEmployeeDto, WorkingTimeRequiredEmployee>();

        }
    }
}
