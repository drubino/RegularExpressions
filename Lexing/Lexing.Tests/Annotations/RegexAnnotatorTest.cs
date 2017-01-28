using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lexing.Tests
{
    [TestClass]
    public abstract class RegexAnnotatorTest : LexingTest
    {
        #region Properties

        internal RegexTerminalNode TerminalNode { get; set; }

        #endregion //Properties

        #region EmptyTest

        /// <summary>
        /// Pattern: ""
        /// </summary>
        [TestMethod]
        public void EmptyTest()
        {
            EmptyTest(ParseForTest(@""));
        }

        /// <summary>
        /// Pattern: ""
        /// </summary>
        internal abstract void EmptyTest(RegexNode node);

        #endregion //EmptyTest

        #region CharacterTest

        /// <summary>
        /// Pattern: "a"
        /// </summary>
        [TestMethod]
        public void CharacterTest()
        {
            CharacterTest(ParseForTest(@"a"));
        }

        /// <summary>
        /// Pattern: "a"
        /// </summary>
        internal abstract void CharacterTest(RegexNode node);

        #endregion //CharacterTest

        #region WildcardTest

        /// <summary>
        /// Pattern: "."
        /// </summary>
        [TestMethod]
        public void WildcardTest()
        {
            WildcardTest(ParseForTest(@"."));
        }

        /// <summary>
        /// Pattern: "."
        /// </summary>
        internal abstract void WildcardTest(RegexNode node);

        #endregion //WildcardTest

        #region DigitTest

        /// <summary>
        /// Pattern: "\d"
        /// </summary>
        [TestMethod]
        public void DigitTest()
        {
            DigitTest(ParseForTest(@"\d"));
        }

        /// <summary>
        /// Pattern: "\d"
        /// </summary>
        internal abstract void DigitTest(RegexNode node);

        #endregion //DigitTest

        #region CharacterSetTest

        /// <summary>
        /// Pattern: "[ab]"
        /// </summary>
        [TestMethod]
        public void CharacterSetTest()
        {
            CharacterSetTest(ParseForTest(@"[ab]"));
        }

        /// <summary>
        /// Pattern: "[ab]"
        /// </summary>
        internal abstract void CharacterSetTest(RegexNode node);

        #endregion //CharacterSetTest

        #region CharacterRangeTest

        /// <summary>
        /// Pattern: "[a-c]"
        /// </summary>
        [TestMethod]
        public void CharacterRangeTest()
        {
            CharacterRangeTest(ParseForTest(@"[a-c]"));
        }

        /// <summary>
        /// Pattern: "[a-c]"
        /// </summary>
        internal abstract void CharacterRangeTest(RegexNode node);

        #endregion //CharacterRangeTest

        #region CharacterSetNegationTest

        /// <summary>
        /// Pattern: "[^ab]"
        /// </summary>
        [TestMethod]
        public void CharacterSetNegationTest()
        {
            CharacterSetNegationTest(ParseForTest(@"[^ab]"));
        }

        /// <summary>
        /// Pattern: "[^ab]"
        /// </summary>
        internal abstract void CharacterSetNegationTest(RegexNode node);

        #endregion //CharacterSetNegationTest

        #region AlternationTest

        /// <summary>
        /// Pattern: "a|b"
        /// </summary>
        [TestMethod]
        public void AlternationTest()
        {
            AlternationTest(ParseForTest(@"a|b"));
        }

        /// <summary>
        /// Pattern: "a|b"
        /// </summary>
        internal abstract void AlternationTest(RegexNode node);

        #endregion //AlternationTest

        #region ConcatenationTest

        /// <summary>
        /// Pattern: "ab"
        /// </summary>
        [TestMethod]
        public void ConcatenationTest()
        {
            ConcatenationTest(ParseForTest(@"ab"));
        }

        /// <summary>
        /// Pattern: "ab"
        /// </summary>
        internal abstract void ConcatenationTest(RegexNode node);

        #endregion //ConcatenationTest

        #region ZeroOrMoreTest

        /// <summary>
        /// Pattern: "a*"
        /// </summary>
        [TestMethod]
        public void ZeroOrMoreTest()
        {
            ZeroOrMoreTest(ParseForTest(@"a*"));
        }

        /// <summary>
        /// Pattern: "a*"
        /// </summary>
        internal abstract void ZeroOrMoreTest(RegexNode node);

        #endregion //ZeroOrMoreTest

        #region OptionalTest

        /// <summary>
        /// Pattern: "a?"
        /// </summary>
        [TestMethod]
        public void OptionalTest()
        {
            OptionalTest(ParseForTest(@"a?"));
        }

        /// <summary>
        /// Pattern: "a?"
        /// </summary>
        internal abstract void OptionalTest(RegexNode node);

        #endregion //OptionalTest

        #region ParseForTest

        /// <summary>
        /// Calls the RegexParser on the pattern, performs the same pre-processing done for all other test methods,
        /// and returns the top-most node to the left of the terminal node.
        /// </summary>
        /// <param name="pattern">A regular expression pattern.</param>
        /// <returns>The top-most node of the parse tree to the left of the terminal node.</returns>
        internal RegexNode ParseForTest(string pattern)
        {
            return RunBeforeTest(RegexParser.ParseRegex(pattern));
        }

        #endregion //ParseForTest

        #region RunBeforeTest

        internal RegexNode RunBeforeTest(RegexSyntaxTree syntaxTree)
        {
            OnBeforeTest(syntaxTree);
            AssertTerminalCharacter(syntaxTree);
            this.TerminalNode = 
                (RegexTerminalNode)syntaxTree.RootNode.Right;

            return syntaxTree.RootNode.Left;
        }

        #endregion //RunBeforeTest

        #region OnBeforeTest

        /// <summary>
        /// A hook point for modification of the tree before the test.
        /// </summary>
        /// <param name="syntaxTree">The syntax tree that will be tested.</param>
        internal virtual void OnBeforeTest(RegexSyntaxTree syntaxTree) { }

        #endregion //OnBeforeTest

        #region AssertTerminalCharacter

        internal void AssertTerminalCharacter(RegexSyntaxTree syntaxTree)
        {
            var terminalNode = syntaxTree.RootNode.Right as RegexLeafNode;

            Assert.IsNotNull(terminalNode,
                "The parser should returned a RegexSyntaxTree that is not terminated correctly.");

            Assert.IsTrue(terminalNode.IsTerminalNode,
                "The parser should returned a RegexSyntaxTree that is not terminated correctly.");
        }

        #endregion //AssertTerminalCharacter
    }
}
