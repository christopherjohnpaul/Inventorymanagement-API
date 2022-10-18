using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Utility
{
    public class ValidatorUtility
    {

        public static bool IsValidEmail(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidMobileNumber(string mob)
        {
            try
            {
                if (mob.Trim().Length < 10)
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
