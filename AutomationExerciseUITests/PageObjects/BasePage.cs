using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomationExerciseUITests.PageObjects.Pages;
using AutomationExerciseUITests.Settings;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationExerciseUITests.PageObjects
{
    public class BasePage
    {
        public BasePage()
        {
            PageFactory.InitElements(ObjectRepository.Driver, this);
        }

        #region Elements

        [FindsBy(How = How.CssSelector, Using = "a[href*='products']")]
        private IWebElement ProductsNavlink;


        [FindsBy(How = How.CssSelector, Using = "a[href*='login']")]
        private IWebElement LoginNavlink;

        [FindsBy(How = How.CssSelector, Using = "a[href*='delete']")]
        private IWebElement DeleteAccountLink;

        #endregion

        #region Actions
        #endregion

        #region Navigations

        public LoginPage NavigateToLogin()
        {
            LoginNavlink.Click();
            return new LoginPage();
        }

        #endregion
    }
}