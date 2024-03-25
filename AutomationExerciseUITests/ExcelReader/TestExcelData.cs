using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using ExcelDataReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationExerciseUITests.ExcelReader
{
    [TestClass]
    public class TestExcelData
    {
        [TestMethod]
        public void TestReadExcel()
        {
            string xlPath = @"/Users/lucas/Projects/qa/dotnet-selenium-specflow-ddt/AutomationExerciseUITests/Data.xlsx";
            var a = ExcelReader.GetCellData(xlPath, "Bugzilla", 3, 0);
        
            //var b = table.Rows[10][0];
        }
    }
}