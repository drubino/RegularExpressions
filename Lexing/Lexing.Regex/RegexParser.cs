using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Lexing.Regex;
using Infragistics.Documents.Parsing;
using Infragistics.Documents;

namespace Lexing.Regex
{
	internal class RegexParser
	{
        #region Constants

        public const string DefaultTerminalSymbol = "Token";

        #endregion //Constants

        #region Methods

        public static RegexSyntaxTree ParseRegex(string pattern)
        {
            return ParseRegex(DefaultTerminalSymbol, pattern);
        }

        public static RegexSyntaxTree ParseRegex(string pattern, out IEnumerable<string> errors)
        {
            return ParseRegex(DefaultTerminalSymbol, pattern, out errors);
        }

		public static RegexSyntaxTree ParseRegex(string token, string pattern)
		{
			IEnumerable<string> errors;
			var tree = RegexParser.ParseRegex(token, pattern, out errors);

			if (tree == null || errors.Any())
			{
				Utilities.DebugFail("There was an error parsing the tree.");
				return null;
			}

			return tree;
		}

        public static RegexSyntaxTree ParseRegex(string token, string pattern, out IEnumerable<string> errors)
		{
			errors = Enumerable.Empty<string>();

			var document = new TextDocument();
			document.Language = RegexLanguage.Instance;
			document.Append(pattern);
			document.Parse();

			var syntaxTree = document.SyntaxTree;
			if (syntaxTree == null)
			{
				errors = RegexParser.GetDefaultErrorForPattern(pattern);
				return null;
			}

			if (syntaxTree.RootNode.ContainsErrors)
			{
				errors = from parseError in syntaxTree.RootNode.GetErrors() select parseError.ToString();
				return null;
			}

			var generator = new RegexSyntaxTreeGenerator(token);
			var abstractTree = generator.GenerateAbstractTree(syntaxTree);

			if (abstractTree == null)
				errors = generator.ErrorMessages ?? RegexParser.GetDefaultErrorForPattern(pattern);

			return abstractTree;
		}

        #endregion //Methods

        #region Utilities

        private static IEnumerable<string> GetDefaultErrorForPattern(string pattern)
		{
			return new string[]
			{
				string.Format("{0} - There was an error parsing the regular expression.", pattern) // TODO_Localize
			};
        }

        #endregion //Utilities
    }
}