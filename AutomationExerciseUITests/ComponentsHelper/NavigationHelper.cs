using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomationExerciseUITests.Settings;

namespace AutomationExerciseUITests.ComponentsHelper
{
    public class NavigationHelper
    {
        public static void NavigateToUrl(string url)
        {
            ObjectRepository.Driver.Navigate().GoToUrl(url);
        }
    }
}