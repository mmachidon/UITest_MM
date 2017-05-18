using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using log4net;
using TechTalk.SpecFlow;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace UITest.Page_Objects
{
    public class HomePage : WebPage
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        IWebElement userNameHeader;
        private string UserSurname;
        private string UserFirstName;
        private static string USERNAME_HEADER = "//h2[contains(text(), ";
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement UserNameHeader
        {
            get
            {
                if (userNameHeader == null)
                    userNameHeader = driver.FindElement(By.XPath(USERNAME_HEADER + " '" + UserSurname + " " + UserFirstName + "')]"));
                return userNameHeader;
            }

        }
        public bool IsUserSuccessfullyLogetIn(string Surname, string FirstName)
        {      
            try
            {
                UserFirstName = FirstName;
                UserSurname = Surname;
                return UserNameHeader.Displayed;
            }
            catch (Exception e)
            {
                Logger.Error("Error: ", e);
                throw (e);
            }

        }

    }
}
