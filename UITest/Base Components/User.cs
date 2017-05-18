using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITest.Base_Components
{
    public class User
    {
        private static string EMAIL_DOMAIN = "@mailinator.com";
        private static string USER_NAME_PREFIX = "test_user_";

        public string LoginName;
        public string FirstName;
        public string LastName;
        public string Password;
        public string EmailAddress;

        public void SetUserLoginName()
        {
            Random rnd = new Random();
            int randomId = rnd.Next(1, 10000);
            LoginName = USER_NAME_PREFIX + randomId + EMAIL_DOMAIN;
        }

    }
}
