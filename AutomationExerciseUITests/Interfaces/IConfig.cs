using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomationExerciseUITests.Configuration;
using OpenQA.Selenium.DevTools.V120.Browser;

namespace AutomationExerciseUITests.Interfaces
{
    public interface IConfig
    {
        BrowserType GetBrowser();
        string GetUsername();
        string GetPassword();
        string GetWebsite();
    }
}