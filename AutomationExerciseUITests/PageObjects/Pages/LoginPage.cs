using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomationExerciseUITests.Settings;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationExerciseUITests.PageObjects.Pages
{
    public class LoginPage : BasePage
    {
        #region Elements

        [FindsBy(How = How.CssSelector, Using = "[data-qa='login-email']")]
        private IWebElement EmailInput;
        
        [FindsBy(How = How.CssSelector, Using = "[data-qa='login-password']")]
        private IWebElement PasswordInput;

        [FindsBy(How = How.CssSelector, Using = "[data-qa='login-button']")]
        private IWebElement LoginButton;

        [FindsBy(How = How.CssSelector, Using = "i[class*='fa-user'] + b")]
        private IWebElement AuthenticatedUser;



        #endregion

        #region Actions

        public BasePage Login(string email, string password)
        {
            EmailInput.SendKeys(email);
            PasswordInput.SendKeys(password);
            LoginButton.Click();
            return new BasePage();
        }

        public string GetAuthenticatedUser()
        {
            return AuthenticatedUser.Text;
        }

        #endregion
        
    }
}