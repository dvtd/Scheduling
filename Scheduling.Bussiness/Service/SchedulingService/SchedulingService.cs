using AutoMapper;
using Scheduling.Data.Dtos.ExamGroup;
using Scheduling.Data.Helper;
using Scheduling.Data.Models;
using Scheduling.Data.UnitOfWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Bussiness.Service.SchedulingService
{
    public class SchedulingService : ISchedulingService
    {
        private IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public SchedulingService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<bool> ScheduleEmployee(int examId, int adminId)
        {
            // Get Number of Employee
            IEnumerable<Employee> listEmp = await _uow.EmployeeRepository.Get(
                filter: el => el.RoleId != AppConstants.Roles.Admin.ID,
                orderBy: el => el.OrderBy(el => el.Id));
            int numEmp = listEmp.Count();

            // Get Number of Shift in Exam
            //IEnumerable<ExamGroup> listExamGroup = await _uow.ExamGroupRepository.Get(
            //    filter: el => el.ExamId == examId);
            //int numShift = listExamGroup.Count();

            // Get all exam session in Exam
            IEnumerable<ExamSession> listExamSessionInExam = (await _uow.ExamSessionRepository
                .Get(filter: el => el.ExamGroup.ExamId == examId, includeProperties: "ExamGroup"));

            // Get all exam group which is in Exam Session Of Exam
            var listExamGroup = listExamSessionInExam.GroupBy(el => el.ExamGroupId).OrderBy(el => el.Key);

            // Get Number of Shift in Exam
            int numShift = listExamGroup.Count();


            // Define availability
            int[][] availability = new int[numEmp][];

            // Define preference
            int[][] preference = new int[numEmp][];

            // range shift for each emp
            int[][] rangeShiftForEachEmp = new int[numEmp][];

            // range emp for each shift
            int[][] rangeEmpForEachShift = new int[numShift][];


            // Get All register in exam 
            IEnumerable<Register> listRegister = await _uow.RegisterRepository.Get(
                filter: el => el.ExamGroup.ExamId == examId, includeProperties: "ExamGroup");

            for (int i = 0; i < listEmp.Count(); i++)
            {
                // Get register by employee
                IEnumerable<Register> listGroupByEmp = listRegister
                    .Where(el => el.EmpId == listEmp.ElementAt(i).Id);

                // Change Perfer to 1
                // Define array of available
                int[] arrAvailable = new int[numShift];
                for (int s = 0; s < numShift; s++)
                {
                    arrAvailable[s] = 0;
                }
                foreach (Register reg in listGroupByEmp)
                {
                    // find the index of exam group and add to array with exactly positon
                    int index = listExamGroup.ToList().FindIndex(el => reg.ExamGroupId == el.Key);
                    if (reg.Value == AppConstants.LevelRegistration.Peference.ID)
                    {
                        arrAvailable[index] = AppConstants.LevelRegistration.Available.ID;
                    }
                    else if (reg.Value == AppConstants.LevelRegistration.Available.ID)
                    {
                        arrAvailable[index] = AppConstants.LevelRegistration.Available.ID;
                    }
                }
                availability[i] = arrAvailable;


                // Change Perfer to 1 and Available to 0
                // Define array of available
                int[] arrPreference = new int[numShift];

                for (int s = 0; s < numShift; s++)
                {
                    arrPreference[s] = 0;
                }
                foreach (Register reg in listGroupByEmp)
                {
                    // find the index of exam group and add to array with exactly positon
                    int index = listExamGroup.ToList().FindIndex(el => reg.ExamGroupId == el.Key);
                    if (reg.Value == AppConstants.LevelRegistration.Peference.ID)
                    {
                        arrPreference[index] = AppConstants.LevelRegistration.Available.ID;
                    }
                    else if (reg.Value == AppConstants.LevelRegistration.Available.ID)
                    {
                        arrPreference[index] = 0;
                    }
                }
                preference[i] = arrPreference;

                // Range Shift For Each Emp
                WorkingTimeRequiredEmployee constrainstEmp = (await _uow.WorkingTimeRequiredEmployeeRepository
                    .Get(filter: el => el.EmpId == listEmp.ElementAt(i).Id && el.ExamId == examId))
                    .FirstOrDefault();

                // Define array of min and max shift for each Employee
                List<int> arrShiftForEachEmp = new List<int>();
                int minShift = Convert.ToInt32(Math.Floor((decimal)(constrainstEmp.MinHour / AppConstants.ExamGroup.DURATION_HOUR_IN_EXAM_GROUP)));
                int maxShift = Convert.ToInt32(Math.Ceiling((decimal)(constrainstEmp.MaxHour / AppConstants.ExamGroup.DURATION_HOUR_IN_EXAM_GROUP)));

                arrShiftForEachEmp.Add(minShift);
                arrShiftForEachEmp.Add(maxShift);

                rangeShiftForEachEmp[i] = arrShiftForEachEmp.ToArray();
            }

            // Range Emp For Each Shift
            for (int i = 0; i < listExamGroup.Count(); i++)
            {
                // Define array of min and max emp for each Shift
                List<int> arrEmpForEachShift = new List<int>();

                int minEmpInEachShift = listExamSessionInExam.Where(el => el.ExamGroupId == listExamGroup.ElementAt(i).Key).Count();
                int maxEmpInEachShift = minEmpInEachShift;

                arrEmpForEachShift.Add(minEmpInEachShift);
                arrEmpForEachShift.Add(maxEmpInEachShift);

                rangeEmpForEachShift[i] = arrEmpForEachShift.ToArray();
            }

            // Scheduling Employee
            SchedulingEmployeeUtil util = new SchedulingEmployeeUtil();
            util.numEmp = numEmp;
            util.numShift = numShift;
            util.availability = availability;
            util.preference = preference;
            util.rangeEmpForEachShift = rangeEmpForEachShift;
            util.rangeShiftForEachEmp = rangeShiftForEachEmp;

            int[][] result = util.Schedule();

            if (result != null)
            {
                // For each emp in list Emp
                for (int i = 0; i < listEmp.Count(); i++)
                {
                    // Get list of Exam Group that is matched with Each Emp
                    List<int> list = result[i].ToList();
                    for (int j = 0; j < list.Count(); j++)
                    {
                        // if exam group of that emp equals to 1 therefore add that emp to exam session
                        if (list.ElementAt(j) == 1)
                        {
                            // Get list exam session in Exam Group
                            var examSession = listExamSessionInExam
                                .Where(el => el.ExamGroupId == listExamGroup.ElementAt(j).Key)
                                .OrderBy(el => el.Id).FirstOrDefault();

                            _uow.EmployeeRelatedRepository.Add(new EmployeeRelated()
                            {
                                EmpId = listEmp.ElementAt(i).Id,
                                EmployeeFullname = listEmp.ElementAt(i).Fullname,
                                ExamSessionId = examSession.Id,
                                CreatePerson = adminId.ToString(),
                                CreateTime = DateTime.UtcNow
                            });

                            listExamSessionInExam = listExamSessionInExam.Where(el => el.Id != examSession.Id);
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Can not scheduling");
            }
            return await _uow.SaveAsync() > 0;
        }
    }
}
