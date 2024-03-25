using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomationExerciseUITests.BaseClasses;
using AutomationExerciseUITests.ComponentsHelper;
using AutomationExerciseUITests.PageObjects.Pages;
using AutomationExerciseUITests.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AutomationExerciseUITests.StepDefinitions
{
    [Binding]
    public class StepDefinition
    {

        private LoginPage _loginPage;

        [Given(@"User navigates to Login page")]
        public void GivenUsernavigatestoLoginpage()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            _loginPage = new LoginPage();
        }

        
        [When(@"User enters and email and password")]
        public void WhenUserentersandemailandpassword()
        {
            // Given
            string xlPath = @"/Users/lucas/Projects/qa/dotnet-selenium-specflow-ddt/AutomationExerciseUITests/Data.xlsx";
            string email = (string)ExcelReader.ExcelReader.GetCellData(xlPath, "AutomationExercise", 2, 1);
            string password = (string)ExcelReader.ExcelReader.GetCellData(xlPath, "AutomationExercise", 2, 2);

            _loginPage.NavigateToLogin();
            _loginPage.Login(email, password);    

        }

        [Then(@"User (.*) is authenticated successfully")]
        public void ThenUserisauthenticatedsuccessfully(string user)
        {
            Assert.AreEqual(user, _loginPage.GetAuthenticatedUser());
        }
    }
}