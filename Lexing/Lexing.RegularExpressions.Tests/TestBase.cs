using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lexing.RegularExpressions.Tests
{
    public class TestBase
    {
        public void AssertThrows<TException>(Action action)
            where TException : Exception
        {
            try
            {
                action();
                Assert.Fail();
            }
            catch (TException) { }
        }
    }
}
