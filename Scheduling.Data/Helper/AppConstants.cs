using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Helper
{
    public class AppConstants
    {
        public struct ExamSession
        {
            public struct Status
            {
                public const int OPENED = 1;
                public const int CLOSED = 0;
            }
            public const int NUMBER_OF_STUDENTS = 20;
        }
        
        public struct LevelRegistration
        {
            public struct Peference
            {
                public const int ID = 2;
                public const string NAME = "Peference";
            }
            public struct NotAvailable
            {
                public const int ID = 0;
                public const string NAME = "NotAvailable";
            }
            public struct Available
            {
                public const int ID = 1;
                public const string NAME = "Available";
            }
            public struct FixByAdmin
            {
                public const int ID = 3;
                public const string NAME = "FixByAdmin";
            }
        }
        public struct EmailFormat
        {
            public const string EMAIL_EXTENSION= "fpt.edu.vn";
        }
        public struct ExamStatus
        {
            public const int CLOSED = 0;
            public const int OPENDED = 1;
            public const int DELETE = 2;
        }
        public struct Roles
        {
            public struct Admin
            {
                public const string NAME = "admin";
                public const int ID = 1;
            }
            public struct Employee
            {
                public const string NAME = "employee";
                public const int ID = 2;
            }
            public struct Supervior
            {
                public const string NAME = "supervior";
                public const int ID = 3;
            }

        }
        public struct EmployeeRole
        {
            public const int OVERSEER_1 = 1;
            public const int OVERSEER_2 = 2;
        }

        public struct RoomType
        {
            public const int NORMAL_ROOM = 0;
            public const int MEETING_ROOM = 1;
        }

        public struct ExamGroup
        {
            public const int DURATION_HOUR_IN_EXAM_GROUP = 1;
        }
    }
}
