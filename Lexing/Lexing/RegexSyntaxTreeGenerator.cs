using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using Lexing;
using System.Globalization;
using Infragistics.Documents.Parsing;

namespace Lexing
{
	internal class RegexSyntaxTreeGenerator : RegexConcreteTreeVisitor<RegexNode>
	{
		#region Fields

        private string _terminalSymbol;
		private List<string> _errorMessages;

        #endregion //Fields

        #region Constructors

        public RegexSyntaxTreeGenerator(string terminalSymbol)
        {
            if (terminalSymbol == null)
                throw new ArgumentNullException("terminalSymbol");

            _terminalSymbol = terminalSymbol;
        }

        #endregion //Constructors

        #region Base Class Overrides

        public override RegexNode VisitAlternationExpression(SyntaxNode node)
		{
			Debug.Assert(node.ChildCount == 3, "Unexpected ChildCount");
			if (node.ChildCount < 3)
				return null;

			Debug.Assert(node.GetChild(1).Symbol.Name == RegexSyntaxTreeGenerator.BarTokenSymbolName, "Missing |");

			var left = node.GetChild(0).Accept(this);
			var right = node.GetChild(2).Accept(this);
			if (left == null || right == null)
				return null;

			return new RegexAlternationNode(left, right);
		}

		public override RegexNode VisitAsteriskToken(SyntaxNode node)
		{
			Debug.Assert(node.Parent.Symbol.Name == RegexSyntaxTreeGenerator.CharacterInSetSymbolName, "We should not have visited * outside of a character set.");
			return RegexSyntaxTreeGenerator.GetSingleCharacterNode(node);
		}

		public override RegexNode VisitBackreferenceToken(SyntaxNode node)
		{
			this.OnError(node, "Backreferences are not supported in TerminalSymbol regular expression patterns"); // TODO_Localize
			return null;
		}

		public override RegexNode VisitBalancingGroupExpression(SyntaxNode node)
		{
			this.OnError(node, "Balancing group expressions are not supported in TerminalSymbol regular expression patterns"); // TODO_Localize
			return null;
		}

		public override RegexNode VisitBarToken(SyntaxNode node)
		{
			Debug.Assert(node.Parent.Symbol.Name == RegexSyntaxTreeGenerator.CharacterInSetSymbolName, "We should not have visited | outside of a character set.");
			return RegexSyntaxTreeGenerator.GetSingleCharacterNode(node);
		}

		public override RegexNode VisitBracedQuantifierExpression(SyntaxNode node)
		{
			Debug.Assert(node.ChildCount == 2, "Unexpected ChildCount");
			if (node.ChildCount < 2)
				return null;

			Debug.Assert(node.GetChild(1).Symbol.Name == RegexSyntaxTreeGenerator.BracedQuantifierTokenSymbolName, "Missing {...}");

			var quantifierNode = node.GetChild(1);

			int lowerBound;
			int? upperBound;
			if (this.TryParseBracedQuantifier(quantifierNode, out lowerBound, out upperBound) == false)
				return null;

			var content = node.GetChild(0).Accept(this);
			if (content == null)
				return null;

			// Note: We are using the main node here. All ther uses must clone it.
			var lowerBoundConcatenation = RegexSyntaxTreeGenerator.RepeatNode(content, lowerBound);

			// X{2} is sugar for XX
			if (lowerBound == upperBound)
				return lowerBoundConcatenation;

			// X{2,} is sugar for XXX*
			if (upperBound == null)
			{
				return new RegexConcatenationNode(
					lowerBoundConcatenation,
					new RegexZeroOrMoreNode(content)
				);
			}

			// X{2,5} is sugar for XX(X(X(X)?)?)?, which is sugar for XX(X(X(X|<e>)|<e>)|<e>)
			return new RegexConcatenationNode(
					lowerBoundConcatenation,
					RegexSyntaxTreeGenerator.RepeatOptionalNode(content, upperBound.Value - lowerBound)
				);
		}

		public override RegexNode VisitBracedQuantifierQuestionMarkToken(SyntaxNode node)
		{
			Utilities.DebugFail("We should never visit the BracedQuantifierQuestionMarkToken.");
			return null;
		}

		public override RegexNode VisitBracedQuantifierToken(SyntaxNode node)
		{
			Utilities.DebugFail("We should never visit the BracedQuantifierToken.");
			return null;
		}

		public override RegexNode VisitBracedQuantifierLazyExpression(SyntaxNode node)
		{
			this.OnError(node, "Lazy quantifiers are not supported in TerminalSymbol regular expression patterns"); // TODO_Localize
			return null;
		}

		public override RegexNode VisitCaretToken(SyntaxNode node)
		{
			if (node.Parent.Symbol.Name == RegexSyntaxTreeGenerator.CharacterInSetSymbolName)
				return RegexSyntaxTreeGenerator.GetSingleCharacterNode(node);

			Debug.Assert(node.ChildCount == 0, "Unexpected ChildCount");
			return new RegexSpecialCharacterNode(SpecialCharacterType.StartOfLine);
		}

		public override RegexNode VisitCharacter(SyntaxNode node)
		{
			Debug.Assert(node.ChildCount == 1, "Unexpected ChildCount");
			if (node.ChildCount == 0)
				return null;

			return node.GetChild(0).Accept(this);
		}

		public override RegexNode VisitCharacterCategoryToken(SyntaxNode node)
		{
			Debug.Assert(node.ChildCount == 0, "Unexpected ChildCount");

			var text = node.GetText();
			if (text.Length < 5)
			{
				Utilities.DebugFail("Incorrect chaarcter category format.");
				return null;
			}

			Debug.Assert(text[0] == '\\', "Incorrect chaarcter category format.");
			Debug.Assert(text[1] == 'p' || text[1] == 'P', "Incorrect chaarcter category format.");
			Debug.Assert(text[2] == '{', "Incorrect chaarcter category format.");
			Debug.Assert(text[text.Length - 1] == '}', "Incorrect chaarcter category format.");

			var categoryName = text.Substring(3, text.Length - 4);
			var isInclusive = Char.IsLower(text[1]);
			return new RegexCharacterCategoryNode(categoryName, isInclusive);
		}

		public override RegexNode VisitCharacterExclusionSet(SyntaxNode node)
		{
			var childCount = node.ChildCount;
			Debug.Assert(childCount >= 4, "Unexpected ChildCount");
			if (childCount < 4)
				return null;

			Debug.Assert(node.GetChild(0).Symbol.Name == RegexSyntaxTreeGenerator.OpenBracketTokenSymbolName, "Missing [");
			Debug.Assert(node.GetChild(1).Symbol.Name == RegexSyntaxTreeGenerator.CaretTokenSymbolName, "Missing ^");
			Debug.Assert(node.GetChild(childCount - 1).Symbol.Name == RegexSyntaxTreeGenerator.CloseBracketTokenSymbolName, "Missing ]");

			var characters = new RegexLeafNode[childCount - 3];
			for (int i = 0; i < characters.Length; i++)
			{
				var child = node.GetChild(i + 2).Accept(this);
				if (child == null)
					return null;

				var leafNode = child as RegexLeafNode;
				if (leafNode == null)
				{
					Utilities.DebugFail("We were expecting the child of the character set to be a leaf node.");
					return null;
				}

				characters[i] = leafNode;
			}

			return new RegexCharacterSetNode(characters, false);
		}

		public override RegexNode VisitCharacterInSet(SyntaxNode node)
		{
			Debug.Assert(node.ChildCount == 1, "Unexpected ChildCount");
			if (node.ChildCount == 0)
				return null;

			return node.GetChild(0).Accept(this);
		}

		public override RegexNode VisitCharacterRange(SyntaxNode node)
		{
			Debug.Assert(node.ChildCount == 3, "Unexpected ChildCount");
			if (node.ChildCount < 3)
				return null;

			Debug.Assert(node.GetChild(1).Symbol.Name == RegexSyntaxTreeGenerator.MinusTokenSymbolName, "Missing -");

			var first = node.GetChild(0).Accept(this);
			var last = node.GetChild(2).Accept(this);
			if (first == null || last == null)
				return null;

			var firstCharacter = first as RegexCharacterNode;
			var lastCharacter = last as RegexCharacterNode;
			if (firstCharacter == null || lastCharacter == null)
			{
				Utilities.DebugFail("We should have only had simple characters in a character range.");
				return null;
			}

			if (lastCharacter.Character < firstCharacter.Character)
			{
				this.OnError(node, "The character range is not ordered correctly"); // TODO_Localize
				return null;
			}

			return new RegexCharacterRangeNode(firstCharacter.Character, lastCharacter.Character);
		}

		public override RegexNode VisitCharacterSet(SyntaxNode node)
		{
			var childCount = node.ChildCount;
			Debug.Assert(childCount >= 3, "Unexpected ChildCount");
			if (childCount < 3)
				return null;

			Debug.Assert(node.GetChild(0).Symbol.Name == RegexSyntaxTreeGenerator.OpenBracketTokenSymbolName, "Missing [");
			Debug.Assert(node.GetChild(childCount - 1).Symbol.Name == RegexSyntaxTreeGenerator.CloseBracketTokenSymbolName, "Missing ]");

			var characters = new RegexLeafNode[childCount - 2];
			for (int i = 0; i < characters.Length; i++)
			{
				var child = node.GetChild(i + 1).Accept(this);
				if (child == null)
					return null;

				var leafNode = child as RegexLeafNode;
				if (leafNode == null)
				{
					Utilities.DebugFail("We were expecting the child of the character set to be a leaf node.");
					return null;
				}

				characters[i] = leafNode;
			}

			return new RegexCharacterSetNode(characters, true);
		}

		public override RegexNode VisitCloseBracketToken(SyntaxNode node)
		{
			Debug.Assert(node.Parent.Symbol.Name == RegexSyntaxTreeGenerator.CharacterSymbolName, "We should not have visited ] inside of a character set.");
			return RegexSyntaxTreeGenerator.GetSingleCharacterNode(node);
		}

		public override RegexNode VisitCloseParenToken(SyntaxNode node)
		{
			Debug.Assert(node.Parent.Symbol.Name == RegexSyntaxTreeGenerator.CharacterInSetSymbolName, "We should not have visited ) outside of a character set.");
			return RegexSyntaxTreeGenerator.GetSingleCharacterNode(node);
		}

		public override RegexNode VisitColonToken(SyntaxNode node)
		{
			return RegexSyntaxTreeGenerator.GetSingleCharacterNode(node);
		}

		public override RegexNode VisitConcatenationExpression(SyntaxNode node)
		{
			Debug.Assert(node.ChildCount == 2, "Unexpected ChildCount");
			if (node.ChildCount < 2)
				return null;

			var left = node.GetChild(0).Accept(this);
			var right = node.GetChild(1).Accept(this);
			if (left == null || right == null)
				return null;

			return new RegexConcatenationNode(left, right);
		}

		public override RegexNode VisitConditionalExpression(SyntaxNode node)
		{
			this.OnError(node, "Conditional expressions are not supported in TerminalSymbol regular expression patterns"); // TODO_Localize
			return null;
		}

		public override RegexNode VisitControlCharacterToken(SyntaxNode node)
		{
			this.OnError(node, "Control characters are not supported in TerminalSymbol regular expression patterns"); // TODO_Localize
			return null;
		}

		public override RegexNode VisitDollarSignToken(SyntaxNode node)
		{
			if (node.Parent.Symbol.Name == RegexSyntaxTreeGenerator.CharacterInSetSymbolName)
				return RegexSyntaxTreeGenerator.GetSingleCharacterNode(node);

			Debug.Assert(node.ChildCount == 0, "Unexpected ChildCount");
			return new RegexSpecialCharacterNode(SpecialCharacterType.EndOfLine);
		}

		public override RegexNode VisitDotToken(SyntaxNode node)
		{
			Debug.Assert(node.ChildCount == 0, "Unexpected ChildCount");
			return new RegexSpecialCharacterNode(SpecialCharacterType.Wildcard);
		}

		public override RegexNode VisitEmptyExpression(SyntaxNode node)
		{
			Debug.Assert(node.ChildCount == 0, "Unexpected ChildCount");
			return new RegexEmptyNode();
		}

		public override RegexNode VisitEndingEscapeError(SyntaxNode node)
		{
			Utilities.DebugFail("This token should never be in the parse tree.");
			return null;
		}

		public override RegexNode VisitEndOfFileToken(SyntaxNode node)
		{
			Utilities.DebugFail("We should not visit the end of file token.");
			return null;
		}

		public override RegexNode VisitEqualsToken(SyntaxNode node)
		{
			return RegexSyntaxTreeGenerator.GetSingleCharacterNode(node);
		}

		public override RegexNode VisitEscapedCharacterToken(SyntaxNode node)
		{
			Debug.Assert(node.ChildCount == 0, "Unexpected ChildCount");

			var text = node.GetText();
			if (text.Length < 2)
			{
				Utilities.DebugFail("Cannot access the character index.");
				return null;
			}

			var escapedChar = text[1];

			var characterType = RegexSpecialCharacterNode.ParseEscapedSpecialCharacterType(escapedChar);
			if (characterType != null)
				return new RegexSpecialCharacterNode(characterType.Value);

			var resolvedChar = this.ResolveEscapedCharacter(node, escapedChar);
			if (resolvedChar == null)
				return null;

			return new RegexCharacterNode(escapedChar);
		}

		public override RegexNode VisitExclamationPointToken(SyntaxNode node)
		{
			return RegexSyntaxTreeGenerator.GetSingleCharacterNode(node);
		}

		public override RegexNode VisitGreaterThanToken(SyntaxNode node)
		{
			return RegexSyntaxTreeGenerator.GetSingleCharacterNode(node);
		}

		public override RegexNode VisitGroupName(SyntaxNode node)
		{
			Utilities.DebugFail("We should not be visiting groups names.");
			return null;
		}

		public override RegexNode VisitHexadecimalCharacterToken(SyntaxNode node)
		{
			Debug.Assert(node.ChildCount == 0, "Unexpected ChildCount");

			var text = node.GetText();
			if (text.Length != 4)
			{
				this.OnError(node, "Incorrect hexadecimal character format"); // TODO_Localize
				return null;
			}

			string hexValueText = text.Substring(2);
			int hexValue;
			if (int.TryParse(hexValueText, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out hexValue) == false)
			{
				this.OnError(node, "Incorrect hexadecimal character format"); // TODO_Localize
				return null;
			}

			return new RegexCharacterNode((char)hexValue);
		}

		public override RegexNode VisitLessThanToken(SyntaxNode node)
		{
			return RegexSyntaxTreeGenerator.GetSingleCharacterNode(node);
		}

		public override RegexNode VisitMinusToken(SyntaxNode node)
		{
			return RegexSyntaxTreeGenerator.GetSingleCharacterNode(node);
		}

		public override RegexNode VisitMultiLineComment(SyntaxNode node)
		{
			Utilities.DebugFail("We should never visit comment nodes.");
			return null;
		}

		public override RegexNode VisitNamedBackreferenceToken(SyntaxNode node)
		{
			this.OnError(node, "Backreferences are not supported in TerminalSymbol regular expression patterns"); // TODO_Localize
			return null;
		}

		public override RegexNode VisitNamedGroupExpression(SyntaxNode node)
		{
			// Note: names are ignored for now.
			Debug.Assert(node.ChildCount == 7, "Unexpected ChildCount");
			if (node.ChildCount < 6)
				return null;

			return node.GetChild(5).Accept(this);
		}

		public override RegexNode VisitNegativeLookaheadExpression(SyntaxNode node)
		{
			this.OnError(node, "Zero-width lookahead assertions are not supported in TerminalSymbol regular expression patterns"); // TODO_Localize
			return null;
		}

		public override RegexNode VisitNegativeLookbehindExpression(SyntaxNode node)
		{
			this.OnError(node, "Zero-width lookbehind assertions are not supported in TerminalSymbol regular expression patterns"); // TODO_Localize
			return null;
		}

		public override RegexNode VisitNonBacktrackingExpression(SyntaxNode node)
		{
			this.OnError(node, "Non-backtracking expressions are not supported in TerminalSymbol regular expression patterns"); // TODO_Localize
			return null;
		}

		public override RegexNode VisitNonCapturingGroupExpression(SyntaxNode node)
		{
			this.OnError(node, "Non-capturing expressions are not supported in TerminalSymbol regular expression patterns"); // TODO_Localize
			return null;
		}

		public override RegexNode VisitOctalCharacterToken(SyntaxNode node)
		{
			Debug.Assert(node.ChildCount == 0, "Unexpected ChildCount");

			var text = node.GetText();
			if (text.Length != 3 && text.Length != 4)
			{
				this.OnError(node, "Incorrect octal character format"); // TODO_Localize
				return null;
			}

			string octValueText = text.Substring(1);

			try
			{
				int octValue = Convert.ToInt32(octValueText, 8);
				return new RegexCharacterNode((char)octValue);
			}
			catch
			{
				this.OnError(node, "Incorrect octal character format"); // TODO_Localize
				return null;
			}
		}

		public override RegexNode VisitOneOrMoreExpression(SyntaxNode node)
		{
			Debug.Assert(node.ChildCount == 2, "Unexpected ChildCount");
			if (node.ChildCount < 2)
				return null;

			Debug.Assert(node.GetChild(1).Symbol.Name == RegexSyntaxTreeGenerator.PlusTokenSymbolName, "Missing +");

			var content = node.GetChild(0).Accept(this);
			if (content == null)
				return null;

			return new RegexConcatenationNode(
				content,
				new RegexZeroOrMoreNode(content.DeepClone()));
		}

		public override RegexNode VisitOneOrMoreLazyExpression(SyntaxNode node)
		{
			this.OnError(node, "Lazy quantifiers are not supported in TerminalSymbol regular expression patterns"); // TODO_Localize
			return null;
		}

		public override RegexNode VisitOpenBracketToken(SyntaxNode node)
		{
			Utilities.DebugFail("We should never visit the OpenBracketToken.");
			return null;
		}

		public override RegexNode VisitOpenParenToken(SyntaxNode node)
		{
			Debug.Assert(node.Parent.Symbol.Name == RegexSyntaxTreeGenerator.CharacterInSetSymbolName, "We should not have visited ( outside of a character set.");
			return RegexSyntaxTreeGenerator.GetSingleCharacterNode(node);
		}

		public override RegexNode VisitOptionGlobalExpression(SyntaxNode node)
		{
			this.OnError(node, "Option specifiers are not supported in TerminalSymbol regular expression patterns"); // TODO_Localize
			return null;
		}

		public override RegexNode VisitOptionGlobalExpressions(SyntaxNode node)
		{
			this.OnError(node, "Option specifiers are not supported in TerminalSymbol regular expression patterns"); // TODO_Localize
			return null;
		}

		public override RegexNode VisitOptionLocalExpression(SyntaxNode node)
		{
			this.OnError(node, "Option specifiers are not supported in TerminalSymbol regular expression patterns"); // TODO_Localize
			return null;
		}

		public override RegexNode VisitOptionsSet(SyntaxNode node)
		{
			this.OnError(node, "Option specifiers are not supported in TerminalSymbol regular expression patterns"); // TODO_Localize
			return null;
		}

		public override RegexNode VisitOptionsSpecifier(SyntaxNode node)
		{
			this.OnError(node, "Option specifiers are not supported in TerminalSymbol regular expression patterns"); // TODO_Localize
			return null;
		}

		public override RegexNode VisitParenthesizedExpression(SyntaxNode node)
		{
			Debug.Assert(node.ChildCount == 3, "Unexpected ChildCount");
			if (node.ChildCount < 2)
				return null;

			return node.GetChild(1).Accept(this);
		}

		public override RegexNode VisitPositiveLookaheadExpression(SyntaxNode node)
		{
			this.OnError(node, "Zero-width lookahead assertions are not supported in TerminalSymbol regular expression patterns"); // TODO_Localize
			return null;
		}

		public override RegexNode VisitPositiveLookbehindExpression(SyntaxNode node)
		{
			this.OnError(node, "Zero-width lookbehind assertions are not supported in TerminalSymbol regular expression patterns"); // TODO_Localize
			return null;
		}

		public override RegexNode VisitPlusToken(SyntaxNode node)
		{
			Debug.Assert(node.Parent.Symbol.Name == RegexSyntaxTreeGenerator.CharacterInSetSymbolName, "We should not have visited + outside of a character set.");
			return RegexSyntaxTreeGenerator.GetSingleCharacterNode(node);
		}

		public override RegexNode VisitQuestionMarkToken(SyntaxNode node)
		{
			Debug.Assert(node.Parent.Symbol.Name == RegexSyntaxTreeGenerator.CharacterInSetSymbolName, "We should not have visited ? outside of a character set.");
			return RegexSyntaxTreeGenerator.GetSingleCharacterNode(node);
		}

		public override RegexNode VisitRegexPattern(SyntaxNode node)
		{
			Debug.Assert(node.ChildCount == 2, "Unexpected ChildCount");
			if (node.ChildCount < 2)
				return null;

			Debug.Assert(node.GetChild(1).Symbol == RegexLanguage.Instance.Grammar.EndOfStreamSymbol, "Missing $");
			return node.GetChild(0).Accept(this);
		}

		public override RegexNode VisitSingleLineComment(SyntaxNode node)
		{
			Utilities.DebugFail("We should never visit comment nodes.");
			return null;
		}

		public override RegexNode VisitUnescapedCharacterToken(SyntaxNode node)
		{
			return RegexSyntaxTreeGenerator.GetSingleCharacterNode(node);
		}

		public override RegexNode VisitUnicodeCharacterToken(SyntaxNode node)
		{
			Debug.Assert(node.ChildCount == 0, "Unexpected ChildCount");

			var text = node.GetText();
			if (text.Length != 6)
			{
				Utilities.DebugFail("Incorrect unicode character format");
				return null;
			}

			string hexValueText = text.Substring(2);
			int hexValue;
			if (int.TryParse(hexValueText, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out hexValue) == false)
			{
				this.OnError(node, "Incorrect unicode character format");
				return null;
			}

			return new RegexCharacterNode((char)hexValue);
		}

		public override RegexNode VisitZeroOrMoreExpression(SyntaxNode node)
		{
			Debug.Assert(node.ChildCount == 2, "Unexpected ChildCount");
			if (node.ChildCount < 2)
				return null;

			Debug.Assert(node.GetChild(1).Symbol.Name == RegexSyntaxTreeGenerator.AsteriskTokenSymbolName, "Missing *");

			var content = node.GetChild(0).Accept(this);
			if (content == null)
				return null;

			return new RegexZeroOrMoreNode(content);
		}

		public override RegexNode VisitZeroOrMoreLazyExpression(SyntaxNode node)
		{
			this.OnError(node, "Lazy quantifiers are not supported in TerminalSymbol regular expression patterns"); // TODO_Localize
			return null;
		}

		public override RegexNode VisitZeroOrOneExpression(SyntaxNode node)
		{
			Debug.Assert(node.ChildCount == 2, "Unexpected ChildCount");
			if (node.ChildCount < 2)
				return null;

			Debug.Assert(node.GetChild(1).Symbol.Name == RegexSyntaxTreeGenerator.QuestionMarkTokenSymbolName, "Missing ?");

			var content = node.GetChild(0).Accept(this);
			if (content == null)
				return null;

			return RegexSyntaxTreeGenerator.ZeroOrOneNode(content);
		}

		public override RegexNode VisitZeroOrOneLazyExpression(SyntaxNode node)
		{
			this.OnError(node, "Lazy quantifiers are not supported in TerminalSymbol regular expression patterns"); // TODO_Localize
			return null;
		}

		#endregion // Base Class Overrides

		#region Methods

		#region Public Methods

		#region GenerateAbstractTree

		public RegexSyntaxTree GenerateAbstractTree(SyntaxTree tree)
		{
			var node = tree.RootNode.Accept(this);
			if (node == null)
				return null;

			var rootNode = new RegexConcatenationNode(
				node,
				new RegexTerminalNode(_terminalSymbol));

			return new RegexSyntaxTree(rootNode);
		}

		#endregion // GenerateAbstractTree

		#endregion // Public Methods

		#region Private Methods

		#region GetSingleCharacterNode

		private static RegexCharacterNode GetSingleCharacterNode(SyntaxNode node)
		{
			Debug.Assert(node.ChildCount == 0, "Unexpected ChildCount");

			var text = node.GetText();
			if (text.Length == 0)
			{
				Utilities.DebugFail("Cannot access the character index.");
				return null;
			}

			return new RegexCharacterNode(text[0]);
		}

		#endregion // GetSingleCharacterNode

		#region OnError

		private void OnError(SyntaxNode node, string errorMessage)
		{
			if (_errorMessages == null)
				_errorMessages = new List<string>();

			_errorMessages.Add(string.Format("{0} - {1}", node.GetText(), errorMessage));
		}

		#endregion // OnError

		#region RepeatNode

		private static RegexNode RepeatNode(RegexNode node, int count)
		{
			if (count <= 0)
				return new RegexEmptyNode();

			var childNode = node.DeepClone();
			for (int i = 1; i < count; i++)
			{
				childNode = new RegexConcatenationNode(
					childNode,
					node.DeepClone());
			}

			return childNode;
		}

		#endregion // RepeatNode

		#region RepeatOptionalNode

		private static RegexNode RepeatOptionalNode(RegexNode node, int count)
		{
			Debug.Assert(count > 0, "The count should be positive.");

			var childNode = RegexSyntaxTreeGenerator.ZeroOrOneNode(node.DeepClone());
			for (int i = 1; i < count; i++)
			{
				childNode =
					RegexSyntaxTreeGenerator.ZeroOrOneNode(
						new RegexConcatenationNode(
							node.DeepClone(),
							childNode
						)
					);
			}

			return childNode;
		}

		#endregion // RepeatOptionalNode

		#region ResolveEscapedCharacter

		private char? ResolveEscapedCharacter(SyntaxNode node, char escapedChar)
		{
			switch (escapedChar)
			{
				case 'c':
					this.OnError(node, "Incomplete control character");
					return null;

				case 'k':
					this.OnError(node, "Incomplete backreference expression");
					return null;

				case 'p':
				case 'P':
					this.OnError(node, "Incomplete character category specified");
					return null;

				case 'u':
				case 'x':
					this.OnError(node, "Incomplete hexadecimal value");
					return null;

				case 'a': return '\a';
				case 'b': return '\b';
				case 'e': return '\u001B';
				case 'f': return '\f';
				case 'n': return '\n';
				case 'r': return '\r';
				case 't': return '\t';
				case 'v': return '\v';

				default:
					if (Char.IsLetter(escapedChar))
					{
						this.OnError(node, "Unrecognized escape sequence");
						return null;
					}

					return escapedChar;
			}
		}

		#endregion // ResolveEscapedCharacter

		#region TryParseBracedQuantifier

		private bool TryParseBracedQuantifier(SyntaxNode quantifierNode, out int lowerBound, out int? upperBound)
		{
			var defaultErrorMessage = "Invalid quantifier format"; // TODO_Localize
			var quantifierText = quantifierNode.GetText();

			lowerBound = 0;
			upperBound = null;

			if (quantifierText.Length < 3)
			{
				this.OnError(quantifierNode, defaultErrorMessage);
				return false;
			}

			Debug.Assert(quantifierText[0] == '{', "Invalid quantifier format.");
			Debug.Assert(quantifierText[quantifierText.Length - 1] == '}', "Invalid quantifier format.");

			var quantifierContent = quantifierText.Substring(1, quantifierText.Length - 2);
			var parts = quantifierContent.Split(',');
			if (parts.Length != 1 && parts.Length != 2)
			{
				this.OnError(quantifierNode, defaultErrorMessage);
				return false;
			}

			if (int.TryParse(parts[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out lowerBound) == false)
			{
				this.OnError(quantifierNode, defaultErrorMessage);
				return false;
			}

			if (parts.Length == 1)
			{
				upperBound = lowerBound;
				return true;
			}

			if (parts[1].Length == 0)
				return true;

			int upperBoundTemp;
			if (int.TryParse(parts[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out upperBoundTemp) == false)
			{
				this.OnError(quantifierNode, defaultErrorMessage);
				return false;
			}

			upperBound = upperBoundTemp;
			if (upperBound < lowerBound)
			{
				this.OnError(quantifierNode, "The max cannot be less than the min in the quantifier expression"); // TODO_Localize
				return false;
			}

			return true;
		}

		#endregion // TryParseBracedQuantifier

		#region ZeroOrOneNode

		private static RegexNode ZeroOrOneNode(RegexNode content)
		{
			return new RegexAlternationNode(content, new RegexEmptyNode());
		}

		#endregion // ZeroOrOneNode

		#endregion // Private Methods

		#endregion // Methods

		#region Properties

		#region ErrorMessages

		public List<string> ErrorMessages
		{
			get { return _errorMessages; }
		}

		#endregion // ErrorMessages

		#endregion // Properties
	}
}