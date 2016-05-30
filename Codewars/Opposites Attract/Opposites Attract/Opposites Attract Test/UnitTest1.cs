using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opposites_Attract;

namespace Opposites_Attract_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_LoveFunc()
        {
            Assert.AreEqual(true, Program.Lovefunc(0, 1));
            Assert.AreEqual(false, Program.Lovefunc(2, 2));
            Assert.AreEqual(true, Program.Lovefunc(1, 4));
            Assert.AreEqual(false, Program.Lovefunc(0, 0));
        }
    }
}
