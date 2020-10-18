using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Helper
{
    public class AppUtils
    {
        public static bool CheckValidationEmail(string email)
        {
            if (email != null)
            {
                // get extension of email
                string extension = email.Substring(email.IndexOf("@") + 1);

                // check if extension equals to app extension
                return extension == AppConstants.EmailFormat.EMAIL_EXTENSION;
            }
            return false;
        }
    }
}
