using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomationExerciseUITests.Configuration;
using AutomationExerciseUITests.CustomException;
using AutomationExerciseUITests.Settings;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine.ClientProtocol;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace AutomationExerciseUITests.BaseClasses
{
    [TestClass]
    public class BaseClass
    {
        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            return options;
        }

        // TODO - Implement Firefox options
        // TODO - Implement IE options
        private static IWebDriver GetFirefoxDriver()
        {
            IWebDriver driver = new FirefoxDriver();
            return driver;
        }

        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        private static IWebDriver GetIEDriver()
        {
            IWebDriver driver = new InternetExplorerDriver();
            return driver;
        }

        [AssemblyInitialize]
        public static void InitWebdriver(TestContext tc)
        {
            ObjectRepository.Config = new AppConfigReader();

            try
            {
                ObjectRepository.Config.GetBrowser();
            }
            catch (Exception e)
            {
                if(e is ArgumentException)
                {
                    throw new NoSuitableDriverFound("Driver for browser not found: Supported browsers are Chrome, Firefox or Internet Explorer"); 
                }
                throw e;
            }
        
            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Firefox:
                    ObjectRepository.Driver = GetFirefoxDriver();
                    break;
                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver();
                    break;
                case BrowserType.IExplorer:
                    ObjectRepository.Driver = GetIEDriver();
                    break;
            }
        }

        [AssemblyCleanup]
        public static void TearDown()
        {
            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
            }
        }
    }
}