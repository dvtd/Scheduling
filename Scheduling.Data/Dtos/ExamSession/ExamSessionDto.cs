using Scheduling.Data.Dtos.ExamGroup;
using Scheduling.Data.Dtos.Major.Subject;
using Scheduling.Data.Dtos.Room;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos.ExamSession
{
    public class ExamSessionDto
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public string RoomName { get; set; }
        public int? ExamGroupId { get; set; }
        public string ExamGroupName { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CreatePerson { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string UpdatePerson { get; set; }
        public int? Status { get; set; }
        public int? SubjectId { get; set; }

        public virtual SubjectDto Subject { get; set; }

        public virtual ExamGroupDto ExamGroup { get; set; }
        public virtual RoomDto Room { get; set; }
    }
}
