using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using sum_of_strings;

namespace unit_test_project
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_Add()
        {
            var tstIntgr = new BigInteger("0023");

            //Equal signed numbers only
            Assert.AreEqual("28", tstIntgr.Add(new BigInteger("5")));
            Assert.AreEqual("28", tstIntgr.Add(new BigInteger("000005")));
            Assert.AreEqual("73", tstIntgr.Add(new BigInteger("50")));

            tstIntgr = new BigInteger("-0023");
            Assert.AreEqual("-28", tstIntgr.Add(new BigInteger("-5")));
            Assert.AreEqual("-28", tstIntgr.Add(new BigInteger("-005")));
            Assert.AreEqual("0", new BigInteger("00").Add(new BigInteger("0")));
            Assert.AreEqual("-28", tstIntgr.Add(new BigInteger("-00005")));
            Assert.AreEqual("-73", tstIntgr.Add(new BigInteger("-0050")));
        }

        [TestMethod]
        public void TestMethod_Subtract()
        {
            Assert.AreEqual("0", new BigInteger("00").Add(new BigInteger("-0")));//Exception
            Assert.AreEqual("23", new BigInteger("023").Add(new BigInteger("-0")));
            Assert.AreEqual("23", new BigInteger("-0").Add(new BigInteger("23")));
            Assert.AreEqual("0", new BigInteger("-100").Add(new BigInteger("100")));
            Assert.AreEqual("50", new BigInteger("100").Add(new BigInteger("-50")));
            Assert.AreEqual("-50", new BigInteger("100").Add(new BigInteger("-150")));
        }

        [TestMethod]
        public void TestMethod_SumString()
        {
            Assert.AreEqual("0", new BigInteger("0000").Add(new BigInteger("000")));
            Assert.AreEqual("0", new BigInteger("-0000").Add(new BigInteger("-000")));
            Assert.AreEqual("0", new BigInteger("-0000").Add(new BigInteger("000")));
            Assert.AreEqual("0", new BigInteger("0000").Add(new BigInteger("-000")));

            Assert.AreEqual("100", new BigInteger("050").Add(new BigInteger("00050")));
            Assert.AreEqual("-100", new BigInteger("-0050").Add(new BigInteger("-000050")));
            Assert.AreEqual("0", new BigInteger("-000050").Add(new BigInteger("00050")));
            Assert.AreEqual("0", new BigInteger("000050").Add(new BigInteger("-000050")));
        }
    }
}
