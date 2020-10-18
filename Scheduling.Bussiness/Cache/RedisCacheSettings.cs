using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Bussiness.Cache
{
    public class RedisCacheSettings
    {
        public bool Enabled { get; set; }
        public string ConnectionString { get; set; }
    }
}
