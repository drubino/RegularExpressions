using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lexing.Regex.Tests
{
    [TestClass]
    public class LexerTest : LexingTest
    {
        #region SingleTokenTest

        [TestMethod]
        public void SingleTokenTest()
        {
            var lexer = GetSingleTokenLexer();

            var tokens = lexer.Tokenize("abaabaaab").ToList();
            Assert.IsTrue(tokens.Count == 3);
            AssertTokenValues(tokens[0], "Token A", "ab");
            AssertTokenValues(tokens[1], "Token A", "aab");
            AssertTokenValues(tokens[2], "Token A", "aaab");
        }

        #endregion //SingleTokenTest

        #region SingleTokenErrorTest

        [TestMethod]
        public void SingleTokenErrorTest()
        {
            var lexer = GetSingleTokenLexer();

            var tokens = lexer.Tokenize("abccaab").ToList();
            Assert.IsTrue(tokens.Count == 3);
            AssertTokenValues(tokens[0], "Token A", "ab");
            AssertErrorValues(tokens[1], "cc");
            AssertTokenValues(tokens[2], "Token A", "aab");
        }

        #endregion //SingleTokenErrorTest

        #region IndependentTokensTest

        [TestMethod]
        public void IndependentTokensTest()
        {
            var lexer = GetIndependentTokensLexer();

            var tokens = lexer.Tokenize("abcdaabccd").ToList();
            Assert.IsTrue(tokens.Count == 4);
            AssertTokenValues(tokens[0], "Token A", "ab");
            AssertTokenValues(tokens[1], "Token B", "cd");
            AssertTokenValues(tokens[2], "Token A", "aab");
            AssertTokenValues(tokens[3], "Token B", "ccd");
        }

        #endregion //IndependentTokensTest

        #region IndependentTokensErrorTest

        [TestMethod]
        public void IndependentTokensErrorTest()
        {
            var lexer = GetIndependentTokensLexer();

            var tokens = lexer.Tokenize(" ab cda").ToList();
            Assert.IsTrue(tokens.Count == 5);
            AssertErrorValues(tokens[0], " ");
            AssertTokenValues(tokens[1], "Token A", "ab");
            AssertErrorValues(tokens[2], " ");
            AssertTokenValues(tokens[3], "Token B", "cd");
            AssertErrorValues(tokens[4], "a");
        }

        #endregion //IndependentTokensErrorTest

        #region OverlappingTokensTest

        [TestMethod]
        public void OverlappingTokensTest()
        {
            var lexer = GetOverlappingTokensLexer();

            var tokens = lexer.Tokenize("aabca").ToList();
            Assert.IsTrue(tokens.Count == 3);
            AssertTokenValues(tokens[0], "Token A", "a");
            AssertTokenValues(tokens[1], "Token B", "abc");
            AssertTokenValues(tokens[2], "Token A", "a");
        }

        #endregion //OverlappingTokensTest

        #region OverlappingTokensErrorTest

        [TestMethod]
        public void OverlappingTokensErrorTest()
        {
            var lexer = GetOverlappingTokensLexer();

            var tokens = lexer.Tokenize("abaabc").ToList();
            Assert.IsTrue(tokens.Count == 4);
            AssertTokenValues(tokens[0], "Token A", "a");
            AssertErrorValues(tokens[1], "b");
            AssertTokenValues(tokens[2], "Token A", "a");
            AssertTokenValues(tokens[3], "Token B", "abc");
        }

        #endregion //OverlappingTokensErrorTest

        #region Utilities

        #region AssertTokenValues

        private void AssertTokenValues(Token token, string symbol, string content)
        {
            Assert.IsTrue(token.IsValidToken);
            Assert.AreEqual(symbol, token.Name);
            Assert.AreEqual(content, token.Content);
        }

        #endregion //AssertTokenValues

        #region AssertErrorValues

        private void AssertErrorValues(Token token, string content)
        {
            Assert.IsFalse(token.IsValidToken);
            Assert.AreEqual(content, token.Content);
        }

        #endregion //AssertErrorValues

        #region GetSingleTokenLexer

        private Lexer GetSingleTokenLexer()
        {
            return ParseToLexer(ParseToTree("Token A", "a*b"));
        }

        #endregion //GetSingleTokenLexer

        #region GetIndependentTokensLexer

        private Lexer GetIndependentTokensLexer()
        {
            return ParseToLexer(
                ParseToTree("Token A", "a*b"),
                ParseToTree("Token B", "c*d"));
        }

        #endregion //GetIndependentTokensLexer

        #region GetOverlappingTokensLexer

        private Lexer GetOverlappingTokensLexer()
        {
            return ParseToLexer(
                ParseToTree("Token A", "a"),
                ParseToTree("Token B", "abc"));
        }

        #endregion //GetOverlappingTokensLexer

        #endregion //Utilities
    }
}
