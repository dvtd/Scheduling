using AutoMapper;
using Scheduling.Data.Dtos.Employee;
using Scheduling.Data.Dtos.Semester;
using Scheduling.Data.Dtos.Semester.Course;
using Scheduling.Data.Dtos.Semester.Exan;
using Scheduling.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

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

        }
    }
}
