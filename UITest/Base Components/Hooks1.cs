using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Net.Mail;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using UITest.Base_Components;
using UITest.Page_Objects;
using UITest.Step_Defenition;

namespace UITest
{
   
    [Binding]
    public sealed class Hooks1
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
            Config.SetWebDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Config.driver.Close();

        }
    }
}
