using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sum_Strings_as_Numbers;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("-1", Program.ExcludeLeadingZeros("-001"));
        }
    }
}
