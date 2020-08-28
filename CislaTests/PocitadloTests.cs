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
    public class PocitadloTests
    {
        [TestMethod()]
        public void NSDTest()
        {
            int a = 12;
            int b = 8;

            int expected = 4;
            int result = Pocitadlo.NSD(a, b);

            Assert.AreEqual(expected, result, "NDS počítá blbě!");
        }

        [TestMethod()]
        public void NSDTest2()
        {
            int a = 24;
            int b = 18;

            int expected = 6;
            int result = Pocitadlo.NSD(a, b);

            Assert.AreEqual(expected, result, "NDS počítá blbě!");
        }
    }
}