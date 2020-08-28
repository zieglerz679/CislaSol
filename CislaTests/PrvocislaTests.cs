using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cisla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cisla.Tests
{
    [TestClass()]
    public class PrvocislaTests
    {
        [TestMethod()]
        public void JePrvocisloTest()
        {
            int x = 101;
            bool expected = true;
            bool result = Prvocisla.JePrvocislo(x);

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void JePrvocisloTest3()
        {
            int x = 2;
            bool expected = true;
            bool result = Prvocisla.JePrvocislo(x);

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void JePrvocisloTest4()
        {
            int x = 651547;
            bool expected = false;
            bool result = Prvocisla.JePrvocislo(x);

            Assert.AreEqual(expected, result);
        }
    }
}