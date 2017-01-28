using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lexing.Tests;

namespace Lexing.Tests
{
    [TestClass]
    public class FollowPositionAnnotatorTest : RegexAnnotatorTest
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
            AssertNoFollowPositions(node);
        }

        #endregion //EmptyTest

        #region CharacterTest

        /// <summary>
        /// Pattern: "a"
        /// </summary>
        internal override void CharacterTest(RegexNode node)
        {
            AssertFollowPositions(node, this.TerminalNode);
        }

        #endregion //CharacterTest

        #region WildcardTest

        /// <summary>
        /// Pattern: "."
        /// </summary>
        internal override void WildcardTest(RegexNode node)
        {
            AssertFollowPositions(node, this.TerminalNode);
        }

        #endregion //WildcardTest

        #region DigitTest

        /// <summary>
        /// Pattern: "\d"
        /// </summary>
        internal override void DigitTest(RegexNode node)
        {
            AssertFollowPositions(node, this.TerminalNode);
        }

        #endregion //DigitTest

        #region CharacterSetTest

        /// <summary>
        /// Pattern: "[ab]"
        /// </summary>
        internal override void CharacterSetTest(RegexNode node)
        {
            AssertFollowPositions(node, this.TerminalNode);
        }

        #endregion //CharacterSetTest

        #region CharacterRangeTest

        /// <summary>
        /// Pattern: "[a-c]"
        /// </summary>
        internal override void CharacterRangeTest(RegexNode node)
        {
            AssertFollowPositions(node, this.TerminalNode);
        }

        #endregion //CharacterRangeTest

        #region CharacterSetNegationTest
        
        /// <summary>
        /// Pattern: "[^ab]"
        /// </summary>
        internal override void CharacterSetNegationTest(RegexNode node)
        {
            AssertFollowPositions(node, this.TerminalNode);
        }

        #endregion //CharacterSetNegationTest

        #region AlternationTest

        /// <summary>
        /// Pattern: "a|b"
        /// </summary>
        internal override void AlternationTest(RegexNode node)
        {
            AssertFollowPositions(node[0], this.TerminalNode);
            AssertFollowPositions(node[1], this.TerminalNode);
        }

        #endregion //AlternationTest

        #region ConcatenationTest

        /// <summary>
        /// Pattern: "ab"
        /// </summary>
        internal override void ConcatenationTest(RegexNode node)
        {
            AssertFollowPositions(node[0], node[1]);
            AssertFollowPositions(node[1], this.TerminalNode);
        }

        #endregion //ConcatenationTest

        #region NullableConcatenationTest

        /// <summary>
        /// Pattern: "ab?"
        /// </summary>
        [TestMethod]
        public void NullableConcatenationTest()
        {
            var node = ParseForTest("ab?");
            AssertFollowPositions(node[0], node[1, 0], this.TerminalNode);
            AssertFollowPositions(node[1, 0], this.TerminalNode);
        }

        #endregion //NullableConcatenationTest

        #region ZeroOrMoreTest

        /// <summary>
        /// Pattern: "a*"
        /// </summary>
        internal override void ZeroOrMoreTest(RegexNode node)
        {
            AssertFollowPositions(node[0], node[0], this.TerminalNode);
        }

        #endregion //ZeroOrMoreTest

        #region OptionalTest

        /// <summary>
        /// Pattern: "a?"
        /// </summary>
        internal override void OptionalTest(RegexNode node)
        {
            AssertFollowPositions(node[0], this.TerminalNode);
        }

        #endregion //OptionalTest

        #region Utilities

        private void AssertNoFollowPositions(RegexNode node)
        {
            AssertFollowPositions(node, new RegexNode[0]);
        }

        private void AssertFollowPositions(RegexNode node, params RegexNode[] positions)
        {
            Assert.AreEqual(node.Annotations.FollowPositions.Count(), positions.Count());

            foreach (var position in positions)
                Assert.IsTrue(node.Annotations.FollowPositions.Contains(position));
        }

        #endregion //Utilities
    }
}
