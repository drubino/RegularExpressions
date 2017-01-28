using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lexing.Tests
{
    /// <summary>
    /// A base class for all tests in the Lexing namespace.
    /// </summary>
    [TestClass]
    public class LexingTest
    {
        #region AssertThrows

        protected void AssertThrows<TException>(Action action)
            where TException : Exception
        {
            try
            {
                action();
                Assert.Fail("The action did not throw an exception");
            }
            catch (Exception ex) 
            { 
                if (!typeof(TException).IsAssignableFrom(ex.GetType()))
                    Assert.Fail(string.Format(
                        "The action did not throw an exception of type {0}.", 
                        typeof(TException).Name)); 
            }
        }

        #endregion //AssertThrows

        #region ParseToTree

        internal RegexSyntaxTree ParseToTree(string tokenSymbol, string pattern)
        {
            return RegexParser.ParseRegex(tokenSymbol, pattern);
        }

        #endregion //ParseToTree

        #region ParseToLanguage

        /// <summary>
        /// Parses the regex pattern and converts it into a RegularLanguage.
        /// </summary>
        /// <param name="pattern">The regex pattern to parse.</param>
        /// <returns>The RegularLanguage for the pattern.</returns>
        internal RegularLanguage ParseToLanguage(string pattern)
        {
            var syntaxTree = RegexParser.ParseRegex(pattern);
            var compiler = new RegexSyntaxTreeCompiler(syntaxTree);
            var automaton = compiler.Compile();
            return new RegularLanguage(automaton);
        }

        #endregion //ParseToLanguage

        #region ParseToLexer

        internal Lexer ParseToLexer(params RegexSyntaxTree[] syntaxTrees)
        {
            var compiler = new RegexSyntaxTreeCompiler(syntaxTrees);
            var automaton = compiler.Compile();
            return new Lexer(automaton);
        }

        #endregion //ParseToLexer

        #region AssertContains

        internal void AssertContains(RegularLanguage language, params string[] inputs)
        {
            foreach (var input in inputs)
                Assert.IsTrue(language.Contains(input));
        }

        #endregion //AssertContains

        #region AssertDoesNotContain

        internal void AssertDoesNotContain(RegularLanguage language, params string[] inputs)
        {
            foreach (var input in inputs)
                Assert.IsFalse(language.Contains(input));
        }

        #endregion //AssertDoesNotContain
    }
}
