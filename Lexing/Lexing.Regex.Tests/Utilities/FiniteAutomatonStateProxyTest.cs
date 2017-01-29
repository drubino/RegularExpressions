using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lexing.Regex.Tests
{
    [TestClass]
    public class FiniteAutomatonStateProxyTest : LexingTest
    {
        #region ConstructorTest

        [TestMethod]
        public void ConstructorTest()
        {
            var proxy = CreateProxy(2, 3, 7);
        }

        #endregion //ConstructorTest

        #region EqualsTest

        [TestMethod]
        public void EqualsTest()
        {
            var first = CreateProxy(1);
            var second = CreateProxy(1);
            Assert.AreEqual(first, second);

            first = CreateProxy(1, 3, 5, 8);
            second = CreateProxy(1, 3, 5, 8);
            Assert.AreEqual(first, second);

            first = CreateProxy(1);
            second = CreateProxy(2);
            Assert.AreNotEqual(first, second);

            first = CreateProxy(1, 3);
            second = CreateProxy(1, 3, 7);
            Assert.AreNotEqual(first, second);
        }

        #endregion //EqualsTest

        #region EqualityOperatorTest

        [TestMethod]
        public void EqualityOperatorTest()
        {
            var first = CreateProxy(1);
            var second = CreateProxy(1);
            Assert.IsTrue(first == second);

            first = CreateProxy(1, 3, 5, 8);
            second = CreateProxy(1, 3, 5, 8);
            Assert.IsTrue(first == second);

            first = CreateProxy(1);
            second = CreateProxy(2);
            Assert.IsFalse(first == second);

            first = CreateProxy(1, 3);
            second = CreateProxy(1, 3, 7);
            Assert.IsFalse(first == second);
        }

        #endregion //EqualityOperatorTest

        #region InequalityOperatorTest

        [TestMethod]
        public void InequalityOperatorTest()
        {
            var first = CreateProxy(1);
            var second = CreateProxy(1);
            Assert.IsFalse(first != second);

            first = CreateProxy(1, 3, 5, 8);
            second = CreateProxy(1, 3, 5, 8);
            Assert.IsFalse(first != second);

            first = CreateProxy(1);
            second = CreateProxy(2);
            Assert.IsTrue(first != second);

            first = CreateProxy(1, 3);
            second = CreateProxy(1, 3, 7);
            Assert.IsTrue(first != second);
        }

        #endregion //InequalityOperatorTest

        #region Utilities

        private FiniteAutomatonStateProxy CreateProxy(params uint[] positions)
        {
            return new FiniteAutomatonStateProxy(CreateNodes(positions));
        }

        private IEnumerable<RegexLeafNode> CreateNodes(params uint[] positions)
        {
            return positions.Select(position =>
            {
                var node = new RegexEmptyNode();
                node.Annotations.Position = position;
                return node;
            });
        }

        #endregion //Utilities
    }
}
