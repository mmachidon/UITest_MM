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
using UITest.Page_Objects;

namespace UITest.Step_Defenition
{
    [Binding]
    public class RegistrationPage : WebPage
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string REGISTRATION_URL = "https://site06.qaw04.rxweb-dev.com/en/Website-Sign-Up/";
        private const string EMAIL_TXT_B = "ctl00_centreContentPlaceHolder_ctlSignUp_txtEmail";
        private const string NEXT_BTN = "ctl00_centreContentPlaceHolder_ctlSignUp_submitButton";
        private const string FIRST_NAME_TXT_B = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtFirstname";
        private const string SURNAME_NAME_TXT_B = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtSurname";
        private const string CREATE_PROFILE_CB = "ctl00_centreContentPlaceHolder_ctlCreateProfile_chkTAndC";
        private const string SUBBMIT_BTN = "ctl00_centreContentPlaceHolder_ctlCreateProfile_submitButton";
        private const string PASSWORD_TXT_B = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtPassword";
        private const string CONFIRM_PASSWORD_TXT_B = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtConfirmPassword";

        IWebElement emailTextbox;
        IWebElement nextButton;
        IWebElement firstNameTextbox;
        IWebElement surnameTextbox;
        IWebElement createProfileCheckbox;
        IWebElement submitButton;
        IWebElement passwordTextbox;
        IWebElement confirmPasswordTextbox;

        private IWebElement EmailTextbox
        {
            get
            {
                if (emailTextbox == null)
                    emailTextbox = driver.FindElement(By.Id(EMAIL_TXT_B));
                return emailTextbox;
            }

        }
        private IWebElement NextButton
        {
            get
            {
                if (nextButton == null)
                    nextButton = driver.FindElement(By.Id(NEXT_BTN));
                return nextButton;
            }

        }
        private IWebElement FirstNameTextbox
        {
            get
            {
                if (firstNameTextbox == null)
                    firstNameTextbox = driver.FindElement(By.Id(FIRST_NAME_TXT_B));
                return firstNameTextbox;
            }

        }
        private IWebElement SurnameTextbox
        {
            get
            {
                if (surnameTextbox == null)
                    surnameTextbox = driver.FindElement(By.Id(SURNAME_NAME_TXT_B));
                return surnameTextbox;
            }

        }
        private IWebElement CreateProfileCheckbox
        {
            get
            {
                if (createProfileCheckbox == null)
                    createProfileCheckbox = driver.FindElement(By.Id(CREATE_PROFILE_CB));
                return createProfileCheckbox;
            }

        }
        private IWebElement SubmitButton
        {
            get
            {
                if (submitButton == null)
                    submitButton = driver.FindElement(By.Id(SUBBMIT_BTN));
                return submitButton;
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
        private IWebElement ConfirmPasswordTextbox
        {
            get
            {
                if (confirmPasswordTextbox == null)
                    confirmPasswordTextbox = driver.FindElement(By.Id(CONFIRM_PASSWORD_TXT_B));
                return confirmPasswordTextbox;
            }

        }

        private void SetUserEmail(string UserName)
        {
            try
            {
                Console.WriteLine("Is Email textbox displayed? {0}", EmailTextbox.Displayed);
                EmailTextbox.Clear();
                EmailTextbox.SendKeys(UserName);
            }
            catch (Exception e)
            {
                Logger.Error("Error: ", e);
                throw (e);
            }
        }
        private void ClickNextButton()
        {
            try
            {
                Logger.InfoFormat("Is Login btn displayed? {0}", NextButton.Displayed);
                NextButton.Click();
            }
            catch (Exception e)
            {
                Logger.Error("Error: ", e);
                throw (e);
            }
        }
        private void SetFirstName(string FirstName)
        {
            try
            {
                Console.WriteLine("Is First Name textbox displayed? {0}", FirstNameTextbox.Displayed);
                FirstNameTextbox.Clear();
                FirstNameTextbox.SendKeys(FirstName);
            }
            catch (Exception e)
            {
                Logger.Error("Error: ", e);
                throw (e);
            }
        }
        private void SetSurname(string Surname)
        {
            try
            {
                Console.WriteLine("Is Surname textbox displayed? {0}", SurnameTextbox.Displayed);
                SurnameTextbox.Clear();
                SurnameTextbox.SendKeys(Surname);
            }
            catch (Exception e)
            {
                Logger.Error("Error: ", e);
                throw (e);
            }
        }
        private void ClickCreateProfileCheckbox()
        {
            try
            {
                Logger.InfoFormat("Is Create Profile Checkbox displayed? {0}", CreateProfileCheckbox.Displayed);
                CreateProfileCheckbox.Click();
            }
            catch (Exception e)
            {
                Logger.Error("Error: ", e);
                throw (e);
            }
        }
        private void ClickSubmitButton()
        {
            try
            {
                Logger.InfoFormat("Is Submit Button displayed? {0}", SubmitButton.Displayed);
                SubmitButton.Click();
            }
            catch (Exception e)
            {
                Logger.Error("Error: ", e);
                throw (e);
            }
        }
        private void SetPassword(string Password)
        {
            try
            {
                Console.WriteLine("Is Password textbox displayed? {0}", PasswordTextbox.Displayed);
                PasswordTextbox.Clear();
                PasswordTextbox.SendKeys(Password);
            }
            catch (Exception e)
            {
                Logger.Error("Error: ", e);
                throw (e);
            }
        }
        private void SetConfirmPassword(string Password)
        {
            try
            {
                Console.WriteLine("Is Confirm Password textbox displayed? {0}", ConfirmPasswordTextbox.Displayed);
                ConfirmPasswordTextbox.Clear();
                ConfirmPasswordTextbox.SendKeys(Password);
            }
            catch (Exception e)
            {
                Logger.Error("Error: ", e);
                throw (e);
            }
        }
        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public RegistrationPage Open()
        {
            driver.Url = REGISTRATION_URL;
            return this;
        }
        public void SubmitUserEmail(string UserEmail)
        {
            SetUserEmail(UserEmail);
            ClickNextButton();
        }
        public void SubmitRequiredFields(string FirstName, string LastName, string Password)
        {
            SetFirstName(FirstName);
            SetSurname(LastName);
            SetPassword(Password);
            SetConfirmPassword(Password);
            ClickCreateProfileCheckbox();
            ClickSubmitButton();
        }
    }


}
