using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using log4net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace UITest.Page_Objects
{
    public class LoginPage : WebPage
    {
        private const string LOGIN_URL = "https://site06.qaw04.rxweb-dev.com/en/Website-Sign-Up/Login-Form/";
        private const string USER_NAME_TXT_B = "ctl00_centreContentPlaceHolder_txtUsername";
        private const string PASSWORD_TXT_B = "ctl00_centreContentPlaceHolder_txtPassword";
        private const string LOGIN_BTN = "ctl00_centreContentPlaceHolder_btnLogin";

        IWebElement userNameTextbox;
        IWebElement passwordTextbox;
        IWebElement loginButton;

        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

        }
        public LoginPage Open()
        {
            driver.Url = LOGIN_URL;
            return this;
        }
        private IWebElement UserNameTextbox
        {
            get
            {
                if (userNameTextbox == null)
                    userNameTextbox = driver.FindElement(By.Id(USER_NAME_TXT_B));
                return userNameTextbox;
            }

        }
        private IWebElement PasswordTextbox
        {
            get
            {
                if (passwordTextbox == null)
                    passwordTextbox = driver.FindElement(By.Id(PASSWORD_TXT_B));
                return passwordTextbox;
            }

        }
        private IWebElement LoginButton
        {
            get
            {
                if (loginButton == null)
                    loginButton = driver.FindElement(By.Id(LOGIN_BTN));
                return loginButton;
            }

        }
        private void SetUserName(string UserName)
        {
            Logger.InfoFormat("Is username box displayed? {0}", UserNameTextbox.Displayed);
            UserNameTextbox.Clear();
            UserNameTextbox.SendKeys(UserName);
        }
        private void SetPassword(string Password)
        {
            Logger.InfoFormat("Is username box displayed? {0}", PasswordTextbox.Displayed);
            PasswordTextbox.Clear();
            PasswordTextbox.SendKeys(Password);
        }
        private void ClickLoginButton()
        {
            Logger.InfoFormat("Is Login btn displayed? {0}", LoginButton.Displayed);
            LoginButton.Click();
        }
        public void LoginAs(string UserName, string Password)
        {
            try
            {
                Logger.InfoFormat("Login URL {0}", LOGIN_URL);
                Logger.InfoFormat("UserName: {0}", UserName);
                Logger.InfoFormat("Password: {0}", Password);
                SetUserName(UserName);
                SetPassword(Password);
                ClickLoginButton();
            }
            catch (Exception e)
            {
                Logger.Error("Error: ", e);
                throw (e);
            }
        }
    }
}
