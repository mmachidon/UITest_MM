using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UITest.Base_Components;

using System.Configuration;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace UITest
{

    public static class Config
    {
        public static IWebDriver driver;
        public static InputData inputData = new InputData();

        public static IWebDriver SetWebDriver()
        {
            string path = Path.GetDirectoryName(Directory.GetCurrentDirectory()) + "\\UItest\\packages";

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            options.AddArguments("start-maximized");
            driver = new ChromeDriver(path,options);
            return driver;
        }  
    }

}
