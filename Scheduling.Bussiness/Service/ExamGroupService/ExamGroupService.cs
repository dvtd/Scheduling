using AutoMapper;
using Scheduling.Data.Dtos.ExamGroup;
using Scheduling.Data.Models;
using Scheduling.Data.Repository;
using Scheduling.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Bussiness.Service.ExamGroupService
{
    public class ExamGroupService : BaseService<ExamGroup, ExamGroupDto>, IExamGroupService
    {
        public ExamGroupService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override IGenericRepository<ExamGroup> _reponsitory => _unitOfWork.ExamGroupRepository;

        public async Task<IEnumerable<ExamGroup>> GetListExamGroupForRegistering(int examId)
        {
            // Get List Exam Group in Session
            var listExamGroupInSession = (await _unitOfWork.ExamSessionRepository
                .Get(filter: el => el.ExamGroup.ExamId == examId, includeProperties: "ExamGroup")).GroupBy(el => el.ExamGroupId);

            // Temp list to insert to result list
            List<int> listR = new List<int>();

            // check if exam group is register full enough
            foreach (var ex in listExamGroupInSession)
            {
                // Get list register by exam group Id
                var listRegister = (await _unitOfWork.RegisterRepository
                                    .Get(filter: el => el.ExamGroupId == ex.Key));
                // If register has data
                if (listRegister != null || listRegister.Count() != 0)
                {
                    // Check if number of examGroup in Session is smaller than in Register then insert to Result list
                    int numSessionInExamGroup = ex.Count();
                    int numSessionInRegister = listRegister.Count();

                    if (numSessionInRegister < numSessionInExamGroup)
                    {
                        listR.Add((int)ex.Key);
                    }
                }
                else
                {
                    listR.Add((int)ex.Key);
                }
            }

            IEnumerable<ExamGroup> result = await _unitOfWork.ExamGroupRepository.Get(filter: el => el.ExamId == examId && listR.Contains(el.Id));

            return result;
        }


    }
}
