using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading;

namespace UITest.Page_Objects
{
    public class MailBox : WebPage
    {

        private static string ACTIVATION_SUBSTRING = "https://site06.qaw04.rxweb-dev.com/en/Website-Sign-Up/Activation-Page/?pageculture=en&";
        private static string USER_MAILBOX_URL_PREFIX = "https://www.mailinator.com/inbox2.jsp?to=";
        private static string USER_MAILBOX_URL_POSTFIX = "#/#public_maildirdiv";
        private static string ACTIVATION_EMAIL_SUBJECT = "Activate Your WhiteLabel Site06 Profile";
        private static string MAIL_FRAME = "publicshowmaildivcontent";    

        public MailAddress UserEmailAddress;

        public MailBox(string userName, IWebDriver driver)
        {       
            this.driver = driver;
            UserEmailAddress = new MailAddress(userName);
        }

        public void GetActivationEmail()
        {
            Thread.Sleep(4000);
            driver.Url = USER_MAILBOX_URL_PREFIX + UserEmailAddress.User + USER_MAILBOX_URL_POSTFIX;     
            driver.FindElement(By.XPath("//*[contains(text(),'" + ACTIVATION_EMAIL_SUBJECT + "')]")).Click();
        }
        public string GetActivationLink()
        {
            var iframeSwitch = driver.FindElement(By.Id(MAIL_FRAME));
            driver.SwitchTo().Frame(iframeSwitch);
            Thread.Sleep(2000);
            Regex regex = new Regex(@"activationGuid=\w+");
            Match match = regex.Match(driver.PageSource);
            return ACTIVATION_SUBSTRING + match.Value;
        }

    }
}
