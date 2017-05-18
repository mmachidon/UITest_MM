using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using log4net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using UITest.Base_Components;
using UITest.Page_Objects;
using UITest.Step_Defenition;

namespace UITest
{
        [Binding]       
        public class RegistrationSteps
        {
            public static IWebDriver driver;
            public static InputData inputData;
            public static User user;

            [Given(@"I am a User")]
            public void GivenIAmAUser()
            {
                driver = new InternetExplorerDriver();
                inputData =new InputData();
                user = InputData.user;
            }

            [When(@"I submit a email to Registration Form")]
            public void WhenISubmitAEmailToRegistrationForm()
            {
                var registrationPage = new RegistrationPage(driver);
                registrationPage.Open().SubmitUserEmail(user.LoginName);
            }

            [When(@"submit all required fields")]
            public void WhenSubmitAllRequiredFields()
            {
                var registrationPage = new RegistrationPage(driver);
                registrationPage.SubmitRequiredFields(user.FirstName, user.LastName, user.Password);
            }

            [When(@"I activate newly created account")]
            public void WhenIActivateNewlyCreatedAccount()
            {
                var mailBox = new MailBox(user.LoginName, driver);        
                mailBox.GetActivationEmail();
                driver.Url = mailBox.GetActivationLink();
            }

            [When(@"I login to application")]
            public void WhenILoginToApplication()
            {
                var loginPage = new LoginPage(driver);
                Console.WriteLine("Loggin validation");
                loginPage.Open().LoginAs(user.LoginName, user.Password);
            }

            [Then(@"I see home page")]
            public void ThenISeeHomePage()
            {
                var homePage = new HomePage(driver);
                Assert.IsTrue(homePage.IsUserSuccessfullyLogetIn(user.LastName, user.FirstName), "Account is not created");
            }
        }
    }

