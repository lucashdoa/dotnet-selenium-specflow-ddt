using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomationExerciseUITests.BaseClasses;
using AutomationExerciseUITests.Settings;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AutomationExerciseUITests.Hooks
{
    [Binding]
    public sealed class GeneralHooks
    {
        private static ScenarioContext _scenarioContext;
        private static ExtentReports _extentReports;
        private static ExtentHtmlReporter _extentHtmlReporter;
        public static ExtentTest _feature;
        private static ExtentTest _scenario;

        [BeforeTestRun]
        public static void BeforeTestRun(TestContext testContext)
        {
            BaseClass.InitWebdriver(testContext);

            _extentHtmlReporter = new ExtentHtmlReporter(@"/Users/lucas/Projects/qa/dotnet-selenium-specflow-ddt/AutomationExerciseUITests/");
            _extentHtmlReporter.Config.ReportName = "testreport.html";
            _extentHtmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(_extentHtmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeatureStart(FeatureContext featureContext)
        {
            if(featureContext != null)
            {
                _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
            }
        }

        [BeforeScenario]
        public static void BeforeScenarioStart(ScenarioContext scenarioContext)
        {
            if(scenarioContext != null)
            {
                _scenarioContext = scenarioContext;
                _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title, scenarioContext.ScenarioInfo.Description);
            }
        }

        [AfterStep]
        public void AfterEachStep()
        {
            ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;

            switch(scenarioBlock)
            {
                case ScenarioBlock.Given:
                    if(_scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace);
                    }
                    else
                    {
                        _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                    }
                break;
                case ScenarioBlock.When:
                    if(_scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace);
                    }
                    else
                    {
                        _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                    }
                break;
                case ScenarioBlock.Then:
                    if(_scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace);
                    }
                    else
                    {
                        _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                    }
                break;
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extentReports.Flush();
            
            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
            }
        }
    }
}