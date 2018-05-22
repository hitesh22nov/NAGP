using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAGP_4124_Console;

namespace NAGP_4124_UnitTesting
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void SayHello()
        {
            Program program = new Program();
            Assert.IsTrue(program.SayHello().Equals("Hello"));
        }

        [TestMethod]
        public void PassTest()
        {
            Program program = new Program();
            Assert.IsTrue(program.PassTest().Equals("This test case should pass"));
        }
    }
}
