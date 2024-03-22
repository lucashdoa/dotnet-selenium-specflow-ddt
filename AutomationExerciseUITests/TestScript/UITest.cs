using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomationExerciseUITests.ComponentsHelper;
using AutomationExerciseUITests.ExcelReader;
using AutomationExerciseUITests.PageObject.Pages;
using AutomationExerciseUITests.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationExerciseUITests.TestScript.UITest
{
    [TestClass]
    public class UITest
    {
        [TestMethod]
        public void TestCase2()
        {
            // Given
            string xlPath = @"/Users/lucas/Projects/qa/dotnet-selenium-specflow-ddt/AutomationExerciseUITests/Data.xlsx";
            string email = (string)ExcelReader.ExcelReader.GetCellData(xlPath, "AutomationExercise", 2, 1);
            string password = (string)ExcelReader.ExcelReader.GetCellData(xlPath, "AutomationExercise", 2, 2);

            // When
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            LoginPage loginPage = new LoginPage();
            loginPage.NavigateToLogin();
            loginPage.Login(email, password);

            // Then
            Assert.AreEqual("lucas", loginPage.GetAuthenticatedUser());
        }
    }
}