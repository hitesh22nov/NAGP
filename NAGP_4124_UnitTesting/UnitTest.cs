﻿using System;
using NAGP_4124_Console;
using NUnit.Framework;

namespace NAGP_4124_UnitTesting
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void SayHello()
        {
            Program program = new Program();
            Assert.IsTrue(program.SayHello().Equals("Hello"));
        }

        [Test]
        public void PassTest()
        {
            Program program = new Program();
            Assert.IsTrue(program.PassTest().Equals("This test case should pass"));
        }
    }
}
