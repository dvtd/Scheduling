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

namespace Scheduling.Data.AutoMapper
{
    class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();

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

        }
    }
}
