using System.Configuration;
using AutomationExerciseUITests.Configuration;
using AutomationExerciseUITests.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationExerciseUITests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Test1()
    {
        IConfig config = new AppConfigReader();

        var a = config.GetBrowser();
        var b = config.GetUsername();
    }
}