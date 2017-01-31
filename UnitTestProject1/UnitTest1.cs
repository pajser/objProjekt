using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApplication1;

namespace UnitTestProject1

{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            //priprema
            int ocekivan = 15;

            int dobiven = test_za_test.zbroji(7, 8);

            Assert.AreEqual(ocekivan, dobiven, 3, "Nisu dobro zbrojeni");
        }
    }
}
