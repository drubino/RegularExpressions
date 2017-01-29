using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lexing.Regex.Tests;

namespace Lexing.Regex.Tests
{
    [TestClass]
    public class PositionAnnotatorTest : RegexAnnotatorTest
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
            AssertPosition(node, 1);
        }

        #endregion //EmptyTest

        #region CharacterTest

        /// <summary>
        /// Pattern: "a"
        /// </summary>
        internal override void CharacterTest(RegexNode node)
        {
            AssertPosition(node, 1);
        }

        #endregion //CharacterTest

        #region WildcardTest

        /// <summary>
        /// Pattern: "."
        /// </summary>
        internal override void WildcardTest(RegexNode node)
        {
            AssertPosition(node, 1);
        }

        #endregion //WildcardTest

        #region DigitTest

        /// <summary>
        /// Pattern: "\d"
        /// </summary>
        internal override void DigitTest(RegexNode node)
        {
            AssertPosition(node, 1);
        }

        #endregion //DigitTest

        #region CharacterSetTest

        /// <summary>
        /// Pattern: "[ab]"
        /// </summary>
        internal override void CharacterSetTest(RegexNode node)
        {
            AssertPosition(node[0], 1);
            AssertPosition(node[1], 2);
            AssertPosition(node, 3);
        }

        #endregion //CharacterSetTest

        #region CharacterRangeTest

        /// <summary>
        /// Pattern: "[a-c]"
        /// </summary>
        internal override void CharacterRangeTest(RegexNode node)
        {
            AssertPosition(node[0], 1);
            AssertPosition(node, 2);
        }

        #endregion //CharacterRangeTest

        #region CharacterSetNegationTest
        
        /// <summary>
        /// Pattern: "[^ab]"
        /// </summary>
        internal override void CharacterSetNegationTest(RegexNode node)
        {
            AssertPosition(node[0], 1);
            AssertPosition(node[1], 2);
            AssertPosition(node, 3);
        }

        #endregion //CharacterSetNegationTest

        #region AlternationTest

        /// <summary>
        /// Pattern: "a|b"
        /// </summary>
        internal override void AlternationTest(RegexNode node)
        {
            AssertPosition(node[0], 1);
            AssertPosition(node[1], 2);
        }

        #endregion //AlternationTest

        #region ConcatenationTest

        /// <summary>
        /// Pattern: "ab"
        /// </summary>
        internal override void ConcatenationTest(RegexNode node)
        {
            AssertPosition(node[0], 1);
            AssertPosition(node[1], 2);
        }

        #endregion //ConcatenationTest

        #region ZeroOrMoreTest

        /// <summary>
        /// Pattern: "a*"
        /// </summary>
        internal override void ZeroOrMoreTest(RegexNode node)
        {
            AssertPosition(node[0], 1);
        }

        #endregion //ZeroOrMoreTest

        #region OptionalTest

        /// <summary>
        /// Pattern: "a?"
        /// </summary>
        internal override void OptionalTest(RegexNode node)
        {
            AssertPosition(node[0], 1);
            AssertPosition(node[1], 2);
        }

        #endregion //OptionalTest

        #region Utilities

        private void AssertPosition(RegexNode node, uint position)
        {
            Assert.AreEqual(node.Annotations.Position, position);
        }

        #endregion //Utilities
    }
}
