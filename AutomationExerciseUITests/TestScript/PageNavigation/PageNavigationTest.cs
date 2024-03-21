using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomationExerciseUITests.ComponentsHelper;
using AutomationExerciseUITests.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationExerciseUITests.TestScript.PageNavigation
{
    [TestClass]
    public class PageNavigationTest
    {
        [TestMethod]
        public void OpenPage()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
        }
    }
}