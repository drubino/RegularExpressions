using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lexing.Tests;

namespace Lexing.Tests
{
    [TestClass]
    public class NullableAnnotatorTest : RegexAnnotatorTest
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
            AssertNullable(node);
        }

        #endregion //EmptyTest

        #region CharacterTest

        /// <summary>
        /// Pattern: "a"
        /// </summary>
        internal override void CharacterTest(RegexNode node)
        {
            AssertNotNullable(node);
        }

        #endregion //CharacterTest

        #region WildcardTest

        /// <summary>
        /// Pattern: "."
        /// </summary>
        internal override void WildcardTest(RegexNode node)
        {
            AssertNotNullable(node);
        }

        #endregion //WildcardTest

        #region DigitTest

        /// <summary>
        /// Pattern: "\d"
        /// </summary>
        internal override void DigitTest(RegexNode node)
        {
            AssertNotNullable(node);
        }

        #endregion //DigitTest

        #region CharacterSetTest

        /// <summary>
        /// Pattern: "[ab]"
        /// </summary>
        internal override void CharacterSetTest(RegexNode node)
        {
            AssertNotNullable(node);
        }

        #endregion //CharacterSetTest

        #region CharacterRangeTest

        /// <summary>
        /// Pattern: "[a-c]"
        /// </summary>
        internal override void CharacterRangeTest(RegexNode node)
        {
            AssertNotNullable(node);
        }

        #endregion //CharacterRangeTest

        #region CharacterSetNegationTest
        
        /// <summary>
        /// Pattern: "[^ab]"
        /// </summary>
        internal override void CharacterSetNegationTest(RegexNode node)
        {
            AssertNotNullable(node);
        }

        #endregion //CharacterSetNegationTest

        #region AlternationTest

        /// <summary>
        /// Pattern: "a|b"
        /// </summary>
        internal override void AlternationTest(RegexNode node)
        {
            AssertNotNullable(node);
        }

        #endregion //AlternationTest

        #region ConcatenationTest

        /// <summary>
        /// Pattern: "ab"
        /// </summary>
        internal override void ConcatenationTest(RegexNode node)
        {
            AssertNotNullable(node);
        }

        #endregion //ConcatenationTest

        #region ZeroOrMoreTest

        /// <summary>
        /// Pattern: "a*"
        /// </summary>
        internal override void ZeroOrMoreTest(RegexNode node)
        {
            AssertNullable(node);
        }

        #endregion //ZeroOrMoreTest

        #region OptionalTest

        /// <summary>
        /// Pattern: "a?"
        /// </summary>
        internal override void OptionalTest(RegexNode node)
        {
            AssertNullable(node);
        }

        #endregion //OptionalTest

        #region Utilities

        private void AssertNullable(RegexNode node)
        {
            Assert.IsTrue(node.Annotations.IsNullable);
        }

        private void AssertNotNullable(RegexNode node)
        {
            Assert.IsFalse(node.Annotations.IsNullable);
        }

        #endregion //Utilities
    }
}
