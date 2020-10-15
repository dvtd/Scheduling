using AutoMapper;
using Scheduling.Data.Dtos.RegisterExam.SubjectInExam;
using Scheduling.Data.Helper;
using Scheduling.Data.Models;
using Scheduling.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Bussiness.Service.RegisterExamService
{
    public class RegisterExamService : IRegisterExamService
    {
        private IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public RegisterExamService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<bool> RegisterExam(int sesmesterId, int examId, List<SubjectInExamRequestParam> listSubjectInExam, int empId)
        {

            // Get Valid Room 
            IEnumerable<Room> listRoom = await _uow.RoomRepository.Get();

            foreach (SubjectInExamRequestParam subjectInExam in listSubjectInExam)
            {
                // Get all course in subject
                IEnumerable<Course> listCourse = await _uow.CourseRepository.Get(filter: el => el.SemesterId == sesmesterId && el.SubjectId == subjectInExam.SubjectId, includeProperties: "StudentGroup");

                // Insert into ExamCourse table
                foreach (Course dto in listCourse)
                {
                    _uow.ExamCourseRepository.Add(new ExamCourse()
                    {
                        CourseId = dto.Id,
                        ExamId = examId,
                        NumberOfStudent = 30,
                        CreateTime = DateTime.UtcNow,
                        CreatePerson = empId.ToString()
                    });
                }

                // Number of students in all course of each Subject
                int numOfStudents = listCourse.Sum(el => el.NumberOfStudents).Value;

                // Count number of students in each Course and divide by 20 to get number of sessions in exam
                int numberOfSessionInExam = Convert.ToInt32(Math.Ceiling((double)numOfStudents / AppConstants.ExamSession.NUMBER_OF_STUDENTS));

                // Check if Room is exist in Exam Group 
                var listRoomInSession = (await _uow.ExamSessionRepository
                    .Get(filter: el => el.ExamGroupId == subjectInExam.ExamGroupId))
                    .GroupBy(el => el.ExamGroupId);

                List<int?> listExistRoomInSession = new List<int?>();

                if (listRoomInSession != null)
                {
                    foreach (var el in listRoomInSession)
                    {
                        foreach (var room in el)
                        {
                            listExistRoomInSession.Add(room.RoomId);
                        }
                    }
                }
                // Get List Room valid then insert into Exam Session
                IEnumerable<Room> listValidRoom = (from room in listRoom
                                                   where !listExistRoomInSession.Contains(room.Id)
                                                   select room).ToList();

                // insert into ExamSession table
                // MISSING ALGORITHM to mixing StudentGroup to insert into ExamSession
                for (int i = 0; i < numberOfSessionInExam; i++)
                {
                    _uow.ExamSessionRepository.Add(new ExamSession()
                    {
                        RoomId = listValidRoom.ElementAt(i).Id,
                        RoomName = listValidRoom.ElementAt(i).RoomName,
                        ExamGroupId = subjectInExam.ExamGroupId,
                        CreateTime = DateTime.UtcNow,
                        CreatePerson = empId.ToString(),
                        Status = AppConstants.ExamSession.Status.OPENED
                    });
                }
                await _uow.SaveAsync();
            }

            // Get all the time in exam
            double allTimeInExam = 0;
            // Get All the time duration in exam
            IEnumerable<ExamGroup> listExamGroup = await _uow.ExamGroupRepository.Get(filter: el => el.ExamId == examId, includeProperties: "ExamSession");
            foreach (ExamGroup dto in listExamGroup)
            {
                if (dto.ExamSession != null || dto.ExamSession.Count != 0)
                {
                    var duration = (dto.TimeEnd - dto.TimeBegin).TotalHours;
                    var numberOfSessionInGroup = dto.ExamSession.Count();
                    allTimeInExam += duration * numberOfSessionInGroup;
                }
            }
            // Get all list department and set constraint 
            IEnumerable<Department> listDepartment = await _uow.DepartmentRepository.Get();
            double averageTime = allTimeInExam / listDepartment.Count();
            // define minHour and maxHour for each Department
            int minH = Convert.ToInt32(Math.Floor(averageTime));
            int maxH = Convert.ToInt32(Math.Ceiling(averageTime));
            foreach (Department dto in listDepartment)
            {
                _uow.WorkingTimeRequiredDepartmentRepository.Add(new WorkingTimeRequiredDepartment()
                {
                    DepartmentId = dto.Id,
                    ExamId = examId,
                    MinHour = minH,
                    MaxHour = maxH,
                    CreateTime = DateTime.UtcNow,
                    CreatePerson = empId.ToString(),
                });
            }
            //Get all list employee and set constraint
            IEnumerable<Employee> listEmployee = await _uow.EmployeeRepository.Get(filter: el => el.RoleId != AppConstants.Roles.Admin.ID, includeProperties: "Department");
            // define minHour and maxHour for each employee in Department
            int minHour = minH / listEmployee.GroupBy(el => el.DepartmentId).Count() + 2;
            int maxHour = maxH / listEmployee.GroupBy(el => el.DepartmentId).Count() + 2;
            foreach (Employee dto in listEmployee)
            {
                _uow.WorkingTimeRequiredEmployeeRepository.Add(new WorkingTimeRequiredEmployee()
                {
                    EmpId = dto.Id,
                    ExamId = examId,
                    MinHour = minHour,
                    MaxHour = maxHour,
                    CreateTime = DateTime.UtcNow,
                    CreatePerson = empId.ToString(),
                });
            }
            return await _uow.SaveAsync() > 0;
        }
    }
}
