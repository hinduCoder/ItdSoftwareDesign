using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyDomain;

namespace SupplyDomain.Tests {
    [TestClass]
    public class Tests {
        [TestMethod]
        public void Test_Period_1() {
            var now = DateTime.Now;
            var period = new Period(now.AddMonths(-8));
            period.Months = 2;
            Assert.IsTrue(period.IsDueDateToday);
        }
        [TestMethod]
        public void Test_Period_2() {
            var startPeriodDate = DateTime.Now.AddMonths(-8).AddYears(-6);
            if((DateTime.Now.Year - startPeriodDate.Year) % 2 != 0)
                startPeriodDate = startPeriodDate.AddYears(-1);
            var period = new Period(startPeriodDate);
            period.Months = 4;
            period.Years = 2;
            Assert.IsTrue(period.IsDueDateToday);
        }
        [TestMethod]
        public void Test_Period_3() {
            var period = new Period(DateTime.Now.AddMonths(-8).AddYears(-6));
            period.Months = 3;
            period.Years = 2;
            Assert.IsFalse(period.IsDueDateToday);
        }
    }
}
