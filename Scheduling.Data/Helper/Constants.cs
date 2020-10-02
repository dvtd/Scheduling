using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Helper
{
    public class Constants
    {
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

        }
        public struct EmployeeRole
        {
            public const int OVERSEER1 = 1;
            public const int OVERSEER2 = 2;
        }
    }
}
