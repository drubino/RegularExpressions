using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lexing.Regex.Tests;

namespace Lexing.Regex.Tests
{
    [TestClass]
    public class FirstPositionAnnotatorTest : RegexAnnotatorTest
    {
        #region OnBeforeTest

        internal override void OnBeforeTest(RegexSyntaxTree syntaxTree)
        {
            syntaxTree.Accept(
                new RegexAnnotator(
                    new PositionDispenser()));
        }

        #endregion //OnBeforeTest

        #region EmptyTest

        /// <summary>
        /// Pattern: ""
        /// </summary>
        internal override void EmptyTest(RegexNode node)
        {
            AssertNoFirstPositions(node);
        }

        #endregion //EmptyTest

        #region CharacterTest

        /// <summary>
        /// Pattern: "a"
        /// </summary>
        internal override void CharacterTest(RegexNode node)
        {
            AssertFirstPositions(node, node);
        }

        #endregion //CharacterTest

        #region WildcardTest

        /// <summary>
        /// Pattern: "."
        /// </summary>
        internal override void WildcardTest(RegexNode node)
        {
            AssertFirstPositions(node, node);
        }

        #endregion //WildcardTest

        #region DigitTest

        /// <summary>
        /// Pattern: "\d"
        /// </summary>
        internal override void DigitTest(RegexNode node)
        {
            AssertFirstPositions(node, node);
        }

        #endregion //DigitTest

        #region CharacterSetTest

        /// <summary>
        /// Pattern: "[ab]"
        /// </summary>
        internal override void CharacterSetTest(RegexNode node)
        {
            AssertFirstPositions(node, node);
        }

        #endregion //CharacterSetTest

        #region CharacterRangeTest

        /// <summary>
        /// Pattern: "[a-c]"
        /// </summary>
        internal override void CharacterRangeTest(RegexNode node)
        {
            AssertFirstPositions(node, node);
        }

        #endregion //CharacterRangeTest

        #region CharacterSetNegationTest
        
        /// <summary>
        /// Pattern: "[^ab]"
        /// </summary>
        internal override void CharacterSetNegationTest(RegexNode node)
        {
            AssertFirstPositions(node, node);
        }

        #endregion //CharacterSetNegationTest

        #region AlternationTest

        /// <summary>
        /// Pattern: "a|b"
        /// </summary>
        internal override void AlternationTest(RegexNode node)
        {
            AssertFirstPositions(node, node[0], node[1]);
        }

        #endregion //AlternationTest

        #region ConcatenationTest

        /// <summary>
        /// Pattern: "ab"
        /// </summary>
        internal override void ConcatenationTest(RegexNode node)
        {
            AssertFirstPositions(node, node[0]);
        }

        #endregion //ConcatenationTest

        #region NullableConcatenationTest

        /// <summary>
        /// Pattern: "a?b"
        /// </summary>
        [TestMethod]
        public void NullableConcatenationTest()
        {
            var node = ParseForTest("a?b");
            AssertFirstPositions(node, node[0, 0], node[1]);
        }

        #endregion //NullableConcatenationTest

        #region ZeroOrMoreTest

        /// <summary>
        /// Pattern: "a*"
        /// </summary>
        internal override void ZeroOrMoreTest(RegexNode node)
        {
            AssertFirstPositions(node, node[0]);
        }

        #endregion //ZeroOrMoreTest

        #region OptionalTest

        /// <summary>
        /// Pattern: "a?"
        /// </summary>
        internal override void OptionalTest(RegexNode node)
        {
            AssertFirstPositions(node, node[0]);
        }

        #endregion //OptionalTest

        #region Utilities

        private void AssertNoFirstPositions(RegexNode node)
        {
            AssertFirstPositions(node, new RegexNode[0]);
        }

        private void AssertFirstPositions(RegexNode node, params RegexNode[] positions)
        {
            Assert.AreEqual(node.Annotations.FirstPositions.Count(), positions.Count());

            foreach (var position in positions)
                Assert.IsTrue(node.Annotations.FirstPositions.Contains(position));
        }

        #endregion //Utilities
    }
}
