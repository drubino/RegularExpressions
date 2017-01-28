using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lexing.RegularExpressions.Tests
{
    [TestClass]
    public class CharacterSetTest : TestBase
    {
        #region AddCharacterTest

        [TestMethod]
        public void AddCharacterTest()
        {
            var set = CharacterSet.Create();
            Assert.IsFalse(set.Contains('a'));

            set.AddCharacter('a');
            Assert.IsTrue(set.Contains('a'));
        }

        #endregion //AddCharacterTest

        #region AddCharactersTest

        [TestMethod]
        public void AddCharactersTest()
        {
            var set = CharacterSet.Create();
            Assert.IsFalse(set.Contains('a'));
            Assert.IsFalse(set.Contains('b'));

            set.AddCharacters('a', 'b');
            Assert.IsTrue(set.Contains('a'));
            Assert.IsTrue(set.Contains('b'));
        }

        #endregion //AddCharactersTest

        #region AddRangeTest

        [TestMethod]
        public void AddRangeTest()
        {
            var set = CharacterSet.Create();
            Assert.IsFalse(set.Contains('a'));
            Assert.IsFalse(set.Contains('b'));
            Assert.IsFalse(set.Contains('c'));
            Assert.IsFalse(set.Contains('d'));
            Assert.IsFalse(set.Contains('e'));

            set.AddRange('b', 'd');
            Assert.IsFalse(set.Contains('a'));
            Assert.IsTrue(set.Contains('b'));
            Assert.IsTrue(set.Contains('c'));
            Assert.IsTrue(set.Contains('d'));
            Assert.IsFalse(set.Contains('e'));

            set.AddRange('g', 'g');
            AssertThrows<ArgumentException>(() => set.AddRange('d', 'b'));
        }

        #endregion //AddRangeTest

        #region TakeComplementTest

        [TestMethod]
        public void TakeComplementTest()
        {
            var set = CharacterSet.Create();
            Assert.IsFalse(set.Contains('a'));

            set.TakeComplement();
            Assert.IsTrue(set.Contains('a'));

            set.AddCharacter('a');
            Assert.IsFalse(set.Contains('a'));

            set.TakeComplement();
            Assert.IsTrue(set.Contains('a'));
        }

        #endregion //TakeComplementTest
    }
}
