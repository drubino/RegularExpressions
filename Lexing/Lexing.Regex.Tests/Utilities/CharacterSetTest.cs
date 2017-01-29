using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lexing.Regex.Tests
{
    [TestClass]
    public class CharacterSetTest : LexingTest
    {
        #region AddCharacterTest

        [TestMethod]
        public void AddCharacterTest()
        {
            var set = new CharacterSet();
            Assert.IsFalse(set.Contains('a'));

            set.AddCharacter('a');
            Assert.IsTrue(set.Contains('a'));
        }

        #endregion //AddCharacterTest

        #region AddCharactersTest

        [TestMethod]
        public void AddCharactersTest()
        {
            var set = new CharacterSet();
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
            var set = new CharacterSet();
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

        #region AddSetTest

        [TestMethod]
        public void AddSetTest()
        {
            var set = new CharacterSet()
                .AddSet(new CharacterSet().AddRange('a', 'z'))
                .AddSet(new CharacterSet().AddRange('A', 'Z'));
            Assert.IsTrue(set.Contains('a'));
            Assert.IsTrue(set.Contains('m'));
            Assert.IsTrue(set.Contains('z'));
            Assert.IsTrue(set.Contains('A'));
            Assert.IsTrue(set.Contains('M'));
            Assert.IsTrue(set.Contains('Z'));
            Assert.IsFalse(set.Contains('0'));
            Assert.IsFalse(set.Contains('9'));
            Assert.IsFalse(set.Contains(','));

            set.MakeExclusive();
            Assert.IsFalse(set.Contains('a'));
            Assert.IsFalse(set.Contains('m'));
            Assert.IsFalse(set.Contains('z'));
            Assert.IsFalse(set.Contains('A'));
            Assert.IsFalse(set.Contains('M'));
            Assert.IsFalse(set.Contains('Z'));
            Assert.IsTrue(set.Contains('0'));
            Assert.IsTrue(set.Contains('9'));
            Assert.IsTrue(set.Contains(','));
        }

        #endregion //AddSetTest

        #region MakeExclusiveTest

        [TestMethod]
        public void MakeExclusiveTest()
        {
            var set = new CharacterSet();
            Assert.IsFalse(set.Contains('a'));

            set.MakeExclusive();
            Assert.IsTrue(set.Contains('a'));

            set.AddCharacter('a');
            Assert.IsFalse(set.Contains('a'));

            set.MakeInclusive();
            Assert.IsTrue(set.Contains('a'));
        }

        #endregion //MakeExclusiveTest
    }
}
