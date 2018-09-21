using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpreadSheetAPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheetAPP.Tests
{
    [TestClass()]
    public class SpreadSheetTests
    {
        SpreadSheet sheet;

        [TestInitialize]
        public void Init()
        {
            sheet = new SpreadSheet(10, 10);
        }

        [TestMethod()]
        public void ShowTest()
        {
            sheet.Show();
        }

        [TestMethod()]
        public void SetValueTest()
        {
            int x = 1, y = 1, value = 5;
            sheet.SetValue(x, y, value);
            Assert.AreEqual(sheet.GetValue(x, y), 5);
        }

        [TestMethod()]
        public void GetValueTest()
        {
            int x = 1, y = 1;
            Assert.AreEqual(sheet.GetValue(x, y), 0);
        }
    }
}