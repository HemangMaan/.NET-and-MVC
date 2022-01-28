using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingJan27;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingJan27.Tests
{
    [TestClass()]
    public class IntrestTests
    {
        [TestMethod()]
        public void SimpleIntrestTest()
        {
            Intrest i = new Intrest();
            double expected = 11937.50;
            double actual = i.SimpleIntrest(10000, 0.03875, 5);
            Assert.AreEqual(expected, actual);
            
        }
        [TestMethod()]
        public void discount()
        {
            Intrest i = new Intrest();
            double expected = 3000;
            double actual = i.discount(10000, 30);
            Assert.AreEqual(expected, actual);
            
        }
    }
}