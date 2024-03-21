using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomationExerciseUITests.Interfaces;
using OpenQA.Selenium;

namespace AutomationExerciseUITests.Settings
{
    public class ObjectRepository
    {
       public static IConfig Config { get; set; }
       public static IWebDriver Driver { get; set; }
    }
}