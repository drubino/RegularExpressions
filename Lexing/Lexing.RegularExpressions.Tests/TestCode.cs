using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lexing.RegularExpressions.Tests
{
    [TestClass]
    public class TestCode
    {
        #region ZeroOrMore

        [TestMethod]
        public void ZeroOrMore()
        {
            var expression =
                Expression.Create(
                    CharacterSet.Create()
                    .AddRange('a', 'z')
                    .AddCharacter('0'))
                .ZeroOrMore();

            AssertValue(
                expression.Run("abc000---"), 
                "abc000");

            AssertValue(
                expression.Run("---abc000"),
                "");
        }

        #endregion //ZeroOrMore

        #region Concat

        [TestMethod]
        public void Concat()
        {
            var expression =
                Expression.Create(
                    CharacterSet.Create()
                    .AddRange('a', 'z'))
                .ZeroOrMore()
                .Concat(
                    Expression.Create(
                        CharacterSet.Create()
                        .AddRange('0', '9'))
                    .ZeroOrMore());

            AssertValue(
                expression.Run("abc012---"),
                "abc012");

            AssertValue(
                expression.Run("a0b1c2"),
                "a0");
        }

        #endregion //Concat

        #region Utilities

        private void AssertValue(Result result, string value)
        {
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(value, result.Value);
        }

        private void AssertNoValue(Result result)
        {
            Assert.IsFalse(result.HasValue);
        }

        #endregion //Utilities
    }
}
