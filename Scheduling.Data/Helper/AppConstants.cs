using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Helper
{
    public class AppConstants
    {
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
    }
}
