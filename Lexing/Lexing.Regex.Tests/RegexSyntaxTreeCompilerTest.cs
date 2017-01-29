using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lexing.Regex.Tests
{
    [TestClass]
    public class RegexSyntaxTreeCompilerTest : LexingTest
    {
        #region ConstructorTest

        [TestMethod]
        public void ConstructorTest()
        {
            var compiler =
                new RegexSyntaxTreeCompiler(
                    ParseToTree("FirstToken", "a"),
                    ParseToTree("SecondToken", "b"),
                    ParseToTree("ThirdToken", "c"));

            AssertThrows<ArgumentNullException>(() =>
                compiler = new RegexSyntaxTreeCompiler(null));
            AssertThrows<ArgumentException>(() =>
                compiler = new RegexSyntaxTreeCompiler());
            AssertThrows<ArgumentException>(() => 
                compiler =
                new RegexSyntaxTreeCompiler(
                    ParseToTree("Token", "a"),
                    ParseToTree("Token", "b"),
                    ParseToTree("OtherToken", "c")));
        }

        #endregion //ConstructorTest

        #region EmptyTest

        /// <summary>
        /// Pattern: ""
        /// </summary>
        [TestMethod]
        public void EmptyTest()
        {
            var language = ParseToLanguage(@"");
            AssertContains(language, "");
            AssertDoesNotContain(language, " ", "a", "..."); 

        }

        #endregion //EmptyTest

        #region CharacterTest

        /// <summary>
        /// Pattern: "a"
        /// </summary>
        [TestMethod]
        public void CharacterTest()
        {
            var language = ParseToLanguage(@"a");
            AssertContains(language, "a");
            AssertDoesNotContain(language, "", " ", "aa", "b"); 
        }

        #endregion //CharacterTest

        #region WildcardTest

        /// <summary>
        /// Pattern: "."
        /// </summary>
        [TestMethod]
        public void WildcardTest()
        {
            var language = ParseToLanguage(@".");
            AssertContains(language, "a", "b", "^", "!", "=");
            AssertDoesNotContain(language, "\n", "", "aa", "bb", "^^", "!!", "=="); 
        }

        #endregion //WildcardTest

        #region DigitTest

        /// <summary>
        /// Pattern: "\d"
        /// </summary>
        [TestMethod]
        public void DigitTest()
        {
            var language = ParseToLanguage(@"\d");
            AssertContains(language, "0", "1", "2", "3", "4", "5", "6", "7", "8", "9");
            AssertDoesNotContain(language, "", "00", "a"); 
        }

        #endregion //DigitTest

        #region CharacterSetTest

        /// <summary>
        /// Pattern: "[ab]"
        /// </summary>
        [TestMethod]
        public void CharacterSetTest()
        {
            var language = ParseToLanguage(@"[ab]");
            AssertContains(language, "a", "b");
            AssertDoesNotContain(language, "", "aa", "ab", "bb", "c", " ");
        }

        #endregion //CharacterSetTest

        #region CharacterRangeTest

        /// <summary>
        /// Pattern: "[a-c]"
        /// </summary>
        [TestMethod]
        public void CharacterRangeTest()
        {
            var language = ParseToLanguage(@"[a-c]");
            AssertContains(language, "a", "b", "c");
            AssertDoesNotContain(language, "aa", "bb", "cc", "d", ""); 
        }

        #endregion //CharacterRangeTest

        #region CharacterSetNegationTest

        /// <summary>
        /// Pattern: "[^ab]"
        /// </summary>
        [TestMethod]
        public void CharacterSetNegationTest()
        {
            var language = ParseToLanguage(@"[^ab]");
            AssertContains(language, "c", "d", "e", "1", ".");
            AssertDoesNotContain(language, "a", "b", "", "cc"); 
        }

        #endregion //CharacterSetNegationTest

        #region AlternationTest

        /// <summary>
        /// Pattern: "a|b"
        /// </summary>
        [TestMethod]
        public void AlternationTest()
        {
            var language = ParseToLanguage(@"a|b");
            AssertContains(language, "a", "b");
            AssertDoesNotContain(language, "", "ab", "aa", "bb"); 
        }

        #endregion //AlternationTest

        #region ConcatenationTest

        /// <summary>
        /// Pattern: "ab"
        /// </summary>
        [TestMethod]
        public void ConcatenationTest()
        {
            var language = ParseToLanguage(@"ab");
            AssertContains(language, "ab");
            AssertDoesNotContain(language, "", "a", "b", "aab", "abb");
        }

        #endregion //ConcatenationTest

        #region ZeroOrMoreTest

        /// <summary>
        /// Pattern: "a*"
        /// </summary>
        [TestMethod]
        public void ZeroOrMoreTest()
        {
            var language = ParseToLanguage(@"a*");
            AssertContains(language, "", "a", "aa", "aaaa");
            AssertDoesNotContain(language, "ab", "aaaab", " ", " aaa"); 
        }

        #endregion //ZeroOrMoreTest

        #region OptionalTest

        /// <summary>
        /// Pattern: "a?"
        /// </summary>
        [TestMethod]
        public void OptionalTest()
        {
            var language = ParseToLanguage(@"a?");
            AssertContains(language, "", "a");
            AssertDoesNotContain(language, " ", "aa", "aaa", "b"); 
        }

        #endregion //OptionalTest
    }
}
