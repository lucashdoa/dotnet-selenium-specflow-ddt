using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomationExerciseUITests.CustomException
{
    public class NoSuitableDriverFound : Exception
    {
        public NoSuitableDriverFound(string msg) : base(msg)
        {
            
        }
    }
}