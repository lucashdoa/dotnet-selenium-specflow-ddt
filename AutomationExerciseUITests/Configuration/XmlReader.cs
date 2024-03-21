using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomationExerciseUITests.Interfaces;

namespace AutomationExerciseUITests.Configuration
{
    public class XmlReader : IConfig
    {
        public BrowserType GetBrowser()
        {
            throw new NotImplementedException();
        }

        public string GetPassword()
        {
            throw new NotImplementedException();
        }

        public string GetUsername()
        {
            throw new NotImplementedException();
        }

        public string GetWebsite()
        {
            throw new NotImplementedException();
        }
    }
}