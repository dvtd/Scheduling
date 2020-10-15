using Scheduling.Data.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos.ExamGroup
{
    public class ExamGroupOfEmployee
    {
        public int? ExamGroupId { get; set; }
        public int? ExamId { get; set; }
        public int? EmpId { get; set; }
        public int? Value
        {
            get 
            {
                return Value;
            }
            set
            {
                Value = Value == AppConstants.LevelRegistration.Peference.ID ? AppConstants.LevelRegistration.Available.ID : Value;
            }
        }
        public TimeSpan? TimeBegin { get; set; }
        public TimeSpan? TimeEnd { get; set; }
        public DateTime? ExamDate { get; set; }
    }
}
