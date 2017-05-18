using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITest.Base_Components
{
    public class InputData
    {
        public static User user;
        public User SetUser()
        {
            user = new User();
            user.FirstName = "First Name";
            user.LastName = "Surname";
            user.Password = "Infonet123";
            user.SetUserLoginName();
            return user;
        }
    }
}
