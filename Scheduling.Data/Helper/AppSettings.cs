using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Helper
{
    public class AppSettings
    {
        public static AppSettings Settings { get; set; }
        public string JwtSecret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string JwtEmailEncryption { get; set; }
    }
}
