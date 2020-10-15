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
            var listExamGroupInSession = (await _unitOfWork.ExamSessionRepository
                .Get(filter: el => el.ExamGroup.ExamId == examId, includeProperties: "ExamGroup")).GroupBy(el => el.ExamGroupId);

            List<int> list = new List<int>();
            foreach(var item in listExamGroupInSession)
            {
                list.Add((int)item.Key);
            }
            return await _unitOfWork.ExamGroupRepository.Get(filter: el => el.ExamId == examId && list.Contains(el.Id));
        }
    }
}
