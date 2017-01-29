using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lexing.Regex.Tests
{
	[TestClass]
	public class RegexParserTest
	{
		#region Tests

		#region AlternationTest

		[TestMethod]
		public void AlternationTest()
		{
			var tree = RegexParser.ParseRegex("a|b");
			this.VerifyAlternationNode(tree.ParsedRootNode);
			this.VerifyCharacterNode(tree.ParsedRootNode[0], 'a');
			this.VerifyCharacterNode(tree.ParsedRootNode[1], 'b');

			tree = RegexParser.ParseRegex("a|");
			this.VerifyAlternationNode(tree.ParsedRootNode);
			this.VerifyCharacterNode(tree.ParsedRootNode[0], 'a');
			this.VerifyEmptyNode(tree.ParsedRootNode[1]);

			tree = RegexParser.ParseRegex("|b");
			this.VerifyAlternationNode(tree.ParsedRootNode);
			this.VerifyEmptyNode(tree.ParsedRootNode[0]);
			this.VerifyCharacterNode(tree.ParsedRootNode[1], 'b');

			tree = RegexParser.ParseRegex("|");
			this.VerifyAlternationNode(tree.ParsedRootNode);
			this.VerifyEmptyNode(tree.ParsedRootNode[0]);
			this.VerifyEmptyNode(tree.ParsedRootNode[1]);
		}

		#endregion // AlternationTest

		#region BracedQuantifierTest

		[TestMethod]
		public void BracedQuantifierTest()
		{
			var tree = RegexParser.ParseRegex("a{0}");
			this.VerifyEmptyNode(tree.ParsedRootNode);

			tree = RegexParser.ParseRegex("a{1}");
			this.VerifyCharacterNode(tree.ParsedRootNode, 'a');

			tree = RegexParser.ParseRegex("a{2}");
			this.VerifyConcatenationNode(tree.ParsedRootNode);
			this.VerifyCharacterNode(tree.ParsedRootNode[0], 'a');
			this.VerifyCharacterNode(tree.ParsedRootNode[1], 'a');
			Assert.AreNotSame(tree.ParsedRootNode[0], tree.ParsedRootNode[1], "The content node was not cloned.");

			tree = RegexParser.ParseRegex("a{3}");
			this.VerifyConcatenationNode(tree.ParsedRootNode);
			this.VerifyConcatenationNode(tree.ParsedRootNode[0]);
			this.VerifyCharacterNode(tree.ParsedRootNode[0][0], 'a');
			this.VerifyCharacterNode(tree.ParsedRootNode[0][1], 'a');
			this.VerifyCharacterNode(tree.ParsedRootNode[1], 'a');
			Assert.AreNotSame(tree.ParsedRootNode[0][0], tree.ParsedRootNode[0][1], "The content node was not cloned.");
			Assert.AreNotSame(tree.ParsedRootNode[0][0], tree.ParsedRootNode[1], "The content node was not cloned.");
			Assert.AreNotSame(tree.ParsedRootNode[0][1], tree.ParsedRootNode[1], "The content node was not cloned.");

			tree = RegexParser.ParseRegex("a{1,}");
			this.VerifyConcatenationNode(tree.ParsedRootNode);
			this.VerifyCharacterNode(tree.ParsedRootNode[0], 'a');
			this.VerifyZeroOrMoreNode(tree.ParsedRootNode[1]);
			this.VerifyCharacterNode(tree.ParsedRootNode[1][0], 'a');
			Assert.AreNotSame(tree.ParsedRootNode[0], tree.ParsedRootNode[1][0], "The content node was not cloned.");

			tree = RegexParser.ParseRegex("a{2,}");
			this.VerifyConcatenationNode(tree.ParsedRootNode);
			this.VerifyConcatenationNode(tree.ParsedRootNode[0]);
			this.VerifyCharacterNode(tree.ParsedRootNode[0][0], 'a');
			this.VerifyCharacterNode(tree.ParsedRootNode[0][1], 'a');
			this.VerifyZeroOrMoreNode(tree.ParsedRootNode[1]);
			this.VerifyCharacterNode(tree.ParsedRootNode[1][0], 'a');
			Assert.AreNotSame(tree.ParsedRootNode[0][0], tree.ParsedRootNode[0][1], "The content node was not cloned.");
			Assert.AreNotSame(tree.ParsedRootNode[0][0], tree.ParsedRootNode[1][0], "The content node was not cloned.");
			Assert.AreNotSame(tree.ParsedRootNode[0][1], tree.ParsedRootNode[1][0], "The content node was not cloned.");

			tree = RegexParser.ParseRegex("a{0,0}");
			this.VerifyEmptyNode(tree.ParsedRootNode);

			tree = RegexParser.ParseRegex("a{1,1}");
			this.VerifyCharacterNode(tree.ParsedRootNode, 'a');

			tree = RegexParser.ParseRegex("a{2,2}");
			this.VerifyConcatenationNode(tree.ParsedRootNode);
			this.VerifyCharacterNode(tree.ParsedRootNode[0], 'a');
			this.VerifyCharacterNode(tree.ParsedRootNode[1], 'a');
			Assert.AreNotSame(tree.ParsedRootNode[0], tree.ParsedRootNode[1], "The content node was not cloned.");

			tree = RegexParser.ParseRegex("a{2,4}");
			this.VerifyConcatenationNode(tree.ParsedRootNode);
			this.VerifyConcatenationNode(tree.ParsedRootNode[0]);
			this.VerifyCharacterNode(tree.ParsedRootNode[0][0], 'a');
			this.VerifyCharacterNode(tree.ParsedRootNode[0][1], 'a');
			this.VerifyAlternationNode(tree.ParsedRootNode[1]);
			this.VerifyConcatenationNode(tree.ParsedRootNode[1][0]);
			this.VerifyCharacterNode(tree.ParsedRootNode[1][0][0], 'a');
			this.VerifyAlternationNode(tree.ParsedRootNode[1][0][1]);
			this.VerifyCharacterNode(tree.ParsedRootNode[1][0][1][0], 'a');
			this.VerifyEmptyNode(tree.ParsedRootNode[1][0][1][1]);
			this.VerifyEmptyNode(tree.ParsedRootNode[1][1]);
			Assert.AreNotSame(tree.ParsedRootNode[0][0], tree.ParsedRootNode[0][1], "The content node was not cloned.");
			Assert.AreNotSame(tree.ParsedRootNode[0][0], tree.ParsedRootNode[1][0][0], "The content node was not cloned.");
			Assert.AreNotSame(tree.ParsedRootNode[0][0], tree.ParsedRootNode[1][0][1][0], "The content node was not cloned.");
			Assert.AreNotSame(tree.ParsedRootNode[0][1], tree.ParsedRootNode[1][0][0], "The content node was not cloned.");
			Assert.AreNotSame(tree.ParsedRootNode[0][1], tree.ParsedRootNode[1][0][1][0], "The content node was not cloned.");
			Assert.AreNotSame(tree.ParsedRootNode[1][0][0], tree.ParsedRootNode[1][0][1][0], "The content node was not cloned.");
		}

		#endregion // BracedQuantifierTest

		#region CharacterCategoryTest

		[TestMethod]
		public void CharacterCategoryTest()
		{
			var tree = RegexParser.ParseRegex(@"\p{L}");
			this.VerifyCharacterCategoryNode(tree.ParsedRootNode, "L", true);

			tree = RegexParser.ParseRegex(@"\P{L}");
			this.VerifyCharacterCategoryNode(tree.ParsedRootNode, "L", false);

			tree = RegexParser.ParseRegex(@"\p{IsMiscellaneousMathematicalSymbols-B}");
			this.VerifyCharacterCategoryNode(tree.ParsedRootNode, "IsMiscellaneousMathematicalSymbols-B", true);

			tree = RegexParser.ParseRegex(@"\P{IsMiscellaneousMathematicalSymbols-B}");
			this.VerifyCharacterCategoryNode(tree.ParsedRootNode, "IsMiscellaneousMathematicalSymbols-B", false);
		}

		#endregion // CharacterCategoryTest

		#region CharacterExclusionRangeTest

		[TestMethod]
		public void CharacterExclusionRangeTest()
		{
			var tree = RegexParser.ParseRegex("[^a-z]");
			this.VerifyCharacterSetRangeNode(tree.ParsedRootNode, false,
				new char[] { 'a', 'z' });

			tree = RegexParser.ParseRegex("[^a-zA-Z0-9]");
			this.VerifyCharacterSetRangeNode(tree.ParsedRootNode, false,
				new char[] { 'a', 'z' },
				new char[] { 'A', 'Z' },
				new char[] { '0', '9' });
		}

		#endregion // CharacterExclusionRangeTest

		#region CharacterExclusionSetTest

		[TestMethod]
		public void CharacterExclusionSetTest()
		{
			var tree = RegexParser.ParseRegex("[^a]");
			this.VerifyCharacterSetNode(tree.ParsedRootNode, false, 'a');

			tree = RegexParser.ParseRegex("[^a(^:$=!><*|)+?-]");
			this.VerifyCharacterSetNode(tree.ParsedRootNode, false,
				'a', '(', '^', ':', '$', '=', '!', '>', '<', '*', '|', ')', '+', '?', '-');
		}

		#endregion // CharacterExclusionSetTest

		#region CharacterRangeTest

		[TestMethod]
		public void CharacterRangeTest()
		{
			var tree = RegexParser.ParseRegex("[a-z]");
			this.VerifyCharacterSetRangeNode(tree.ParsedRootNode, true,
				new char[] { 'a', 'z' });

			tree = RegexParser.ParseRegex("[a-zA-Z0-9]");
			this.VerifyCharacterSetRangeNode(tree.ParsedRootNode, true,
				new char[] { 'a', 'z' },
				new char[] { 'A', 'Z' },
				new char[] { '0', '9' });
		}

		#endregion // CharacterRangeTest

		#region CharacterSetTest

		[TestMethod]
		public void CharacterSetTest()
		{
			var tree = RegexParser.ParseRegex("[a]");
			this.VerifyCharacterSetNode(tree.ParsedRootNode, true, 'a');

			tree = RegexParser.ParseRegex("[a(^:$=!><*|)+?-]");
			this.VerifyCharacterSetNode(tree.ParsedRootNode, true,
				'a', '(', '^', ':', '$', '=', '!', '>', '<', '*', '|', ')', '+', '?', '-');
		}

		#endregion // CharacterSetTest

		#region ConcatenationTest

		[TestMethod]
		public void ConcatenationTest()
		{
			var tree = RegexParser.ParseRegex("ab");
			this.VerifyConcatenationNode(tree.ParsedRootNode);
			this.VerifyCharacterNode(tree.ParsedRootNode[0], 'a');
			this.VerifyCharacterNode(tree.ParsedRootNode[1], 'b');
		}

		#endregion // ConcatenationTest

		#region EmptyRegexTest

		[TestMethod]
		public void EmptyRegexTest()
		{
			var tree = RegexParser.ParseRegex("");
			this.VerifyEmptyNode(tree.ParsedRootNode);
		}

		#endregion // EmptyRegexTest

		#region ErrorMessagesTest

		[TestMethod]
		public void ErrorMessagesTest()
		{
			IEnumerable<string> errors;
			var tree = RegexParser.ParseRegex(@"\", out errors);
			this.VerifyErrorMessages(errors, @"Illegal escape character '\' at the end of the regular expression pattern");

			tree = RegexParser.ParseRegex(@"a\", out errors);
			this.VerifyErrorMessages(errors, @"Illegal escape character '\' at the end of the regular expression pattern");

			tree = RegexParser.ParseRegex(@"[a", out errors);
			this.VerifyErrorMessages(errors, @"] expected");

			tree = RegexParser.ParseRegex(@"(a", out errors);
			this.VerifyErrorMessages(errors, @") expected");

			tree = RegexParser.ParseRegex(@"a{2,}?b", out errors);
			this.VerifyErrorMessages(errors, @"a{2,}? - Lazy quantifiers are not supported in TerminalSymbol regular expression patterns");

			tree = RegexParser.ParseRegex(@"[z-a]b", out errors);
			this.VerifyErrorMessages(errors, @"z-a - The character range is not ordered correctly");

			tree = RegexParser.ParseRegex(@"(?(a)b)b", out errors);
			this.VerifyErrorMessages(errors, @"(?(a)b) - Conditional expressions are not supported in TerminalSymbol regular expression patterns");

			tree = RegexParser.ParseRegex(@"\cCb", out errors);
			this.VerifyErrorMessages(errors, @"\cC - Control characters are not supported in TerminalSymbol regular expression patterns");

			tree = RegexParser.ParseRegex(@"(?<Test>a)b\k<Test>", out errors);
			this.VerifyErrorMessages(errors, @"\k<Test> - Backreferences are not supported in TerminalSymbol regular expression patterns");

			tree = RegexParser.ParseRegex(@"(?<!a)b", out errors);
			this.VerifyErrorMessages(errors, @"(?<!a) - Zero-width lookbehind assertions are not supported in TerminalSymbol regular expression patterns");

			tree = RegexParser.ParseRegex(@"(?<=a)b", out errors);
			this.VerifyErrorMessages(errors, @"(?<=a) - Zero-width lookbehind assertions are not supported in TerminalSymbol regular expression patterns");

			tree = RegexParser.ParseRegex(@"(?!a)b", out errors);
			this.VerifyErrorMessages(errors, @"(?!a) - Zero-width lookahead assertions are not supported in TerminalSymbol regular expression patterns");

			tree = RegexParser.ParseRegex(@"(?=a)b", out errors);
			this.VerifyErrorMessages(errors, @"(?=a) - Zero-width lookahead assertions are not supported in TerminalSymbol regular expression patterns");

			tree = RegexParser.ParseRegex(@"(?>a)b", out errors);
			this.VerifyErrorMessages(errors, @"(?>a) - Non-backtracking expressions are not supported in TerminalSymbol regular expression patterns");

			tree = RegexParser.ParseRegex(@"(?:a)b", out errors);
			this.VerifyErrorMessages(errors, @"(?:a) - Non-capturing expressions are not supported in TerminalSymbol regular expression patterns");

			tree = RegexParser.ParseRegex(@"a??b", out errors);
			this.VerifyErrorMessages(errors, @"a?? - Lazy quantifiers are not supported in TerminalSymbol regular expression patterns");

			tree = RegexParser.ParseRegex(@"a+?b", out errors);
			this.VerifyErrorMessages(errors, @"a+? - Lazy quantifiers are not supported in TerminalSymbol regular expression patterns");

			tree = RegexParser.ParseRegex(@"a*?b", out errors);
			this.VerifyErrorMessages(errors, @"a*? - Lazy quantifiers are not supported in TerminalSymbol regular expression patterns");

			tree = RegexParser.ParseRegex(@"(a)b\1", out errors);
			this.VerifyErrorMessages(errors, @"\1 - Backreferences are not supported in TerminalSymbol regular expression patterns");

			tree = RegexParser.ParseRegex(@"(?<Test1>b)(?<Test2-Test1>a)", out errors);
			this.VerifyErrorMessages(errors, @"(?<Test2-Test1>a) - Balancing group expressions are not supported in TerminalSymbol regular expression patterns");

			tree = RegexParser.ParseRegex(@"(?i)a", out errors);
			this.VerifyErrorMessages(errors, @"(?i)a - Option specifiers are not supported in TerminalSymbol regular expression patterns");

			tree = RegexParser.ParseRegex(@"(?i:a)b", out errors);
			this.VerifyErrorMessages(errors, @"(?i:a) - Option specifiers are not supported in TerminalSymbol regular expression patterns");

			tree = RegexParser.ParseRegex(@"a{4,3}b", out errors);
			this.VerifyErrorMessages(errors, @"{4,3} - The max cannot be less than the min in the quantifier expression");

			tree = RegexParser.ParseRegex(@"\p", out errors);
			this.VerifyErrorMessages(errors, @"\p - Incomplete character category specified");

			tree = RegexParser.ParseRegex(@"\P", out errors);
			this.VerifyErrorMessages(errors, @"\P - Incomplete character category specified");

			tree = RegexParser.ParseRegex(@"\x", out errors);
			this.VerifyErrorMessages(errors, @"\x - Incomplete hexadecimal value");

			tree = RegexParser.ParseRegex(@"\u", out errors);
			this.VerifyErrorMessages(errors, @"\u - Incomplete hexadecimal value");

			tree = RegexParser.ParseRegex(@"\k", out errors);
			this.VerifyErrorMessages(errors, @"\k - Incomplete backreference expression");

			tree = RegexParser.ParseRegex(@"\c", out errors);
			this.VerifyErrorMessages(errors, @"\c - Incomplete control character");

			tree = RegexParser.ParseRegex(@"\g", out errors);
			this.VerifyErrorMessages(errors, @"\g - Unrecognized escape sequence");

			tree = RegexParser.ParseRegex(@"a++", out errors);
			this.VerifyErrorMessages(errors, @"Unexpected token '+'");

			tree = RegexParser.ParseRegex(@"a**", out errors);
			this.VerifyErrorMessages(errors, @"Unexpected token '*'");

			tree = RegexParser.ParseRegex(@"+", out errors);
			this.VerifyErrorMessages(errors, @"Unexpected token '+'");

			tree = RegexParser.ParseRegex(@"*", out errors);
			this.VerifyErrorMessages(errors, @"Unexpected token '*'");

			tree = RegexParser.ParseRegex(@"?", out errors);
			this.VerifyErrorMessages(errors, @"Unexpected token '?'");

			tree = RegexParser.ParseRegex(@"?", out errors);
			this.VerifyErrorMessages(errors, @"Unexpected token '?'");
		}

		#endregion // ErrorMessagesTest

		#region GroupedExpressionTest

		[TestMethod]
		public void GroupedExpressionTest()
		{
			var tree = RegexParser.ParseRegex("(a)");
			this.VerifyCharacterNode(tree.ParsedRootNode, 'a');

			tree = RegexParser.ParseRegex("(?<Test>a)");
			this.VerifyCharacterNode(tree.ParsedRootNode, 'a');
		}

		#endregion // GroupedExpressionTest

		#region OneOrMoreTest

		[TestMethod]
		public void OneOrMoreTest()
		{
			var tree = RegexParser.ParseRegex("a+");
			this.VerifyConcatenationNode(tree.ParsedRootNode);
			this.VerifyCharacterNode(tree.ParsedRootNode[0], 'a');
			this.VerifyZeroOrMoreNode(tree.ParsedRootNode[1]);
			this.VerifyCharacterNode(tree.ParsedRootNode[1][0], 'a');
		}

		#endregion // OneOrMoreTest

		#region SingleCharacterTest

		[TestMethod]
		public void SingleCharacterTest()
		{
			var tree = RegexParser.ParseRegex("a");
			this.VerifyCharacterNode(tree.ParsedRootNode, 'a');

			tree = RegexParser.ParseRegex(@"\.");
			this.VerifyCharacterNode(tree.ParsedRootNode, '.');

			tree = RegexParser.ParseRegex(@"]");
			this.VerifyCharacterNode(tree.ParsedRootNode, ']');

			tree = RegexParser.ParseRegex(@":");
			this.VerifyCharacterNode(tree.ParsedRootNode, ':');

			tree = RegexParser.ParseRegex(@"=");
			this.VerifyCharacterNode(tree.ParsedRootNode, '=');

			tree = RegexParser.ParseRegex(@"!");
			this.VerifyCharacterNode(tree.ParsedRootNode, '!');

			tree = RegexParser.ParseRegex(@"<");
			this.VerifyCharacterNode(tree.ParsedRootNode, '<');

			tree = RegexParser.ParseRegex(@">");
			this.VerifyCharacterNode(tree.ParsedRootNode, '>');

			tree = RegexParser.ParseRegex(@"-");
			this.VerifyCharacterNode(tree.ParsedRootNode, '-');

			tree = RegexParser.ParseRegex(@"\172");
			this.VerifyCharacterNode(tree.ParsedRootNode, '\u007A');

			tree = RegexParser.ParseRegex(@"\xF0");
			this.VerifyCharacterNode(tree.ParsedRootNode, '\u00F0');

			tree = RegexParser.ParseRegex(@"\u1A7F");
			this.VerifyCharacterNode(tree.ParsedRootNode, '\u1A7F');
		}

		#endregion // SingleCharacterTest

		#region SpecialCharacterTest

		[TestMethod]
		public void SpecialCharacterTest()
		{
			var tree = RegexParser.ParseRegex(@".");
			this.VerifySpecialCharacterNode(tree.ParsedRootNode, SpecialCharacterType.Wildcard);

			tree = RegexParser.ParseRegex(@"^");
			this.VerifySpecialCharacterNode(tree.ParsedRootNode, SpecialCharacterType.StartOfLine);

			tree = RegexParser.ParseRegex(@"$");
			this.VerifySpecialCharacterNode(tree.ParsedRootNode, SpecialCharacterType.EndOfLine);

			tree = RegexParser.ParseRegex(@"\A");
			this.VerifySpecialCharacterNode(tree.ParsedRootNode, SpecialCharacterType.StartOfString);

			tree = RegexParser.ParseRegex(@"\b");
			this.VerifySpecialCharacterNode(tree.ParsedRootNode, SpecialCharacterType.Boundary);

			tree = RegexParser.ParseRegex(@"\B");
			this.VerifySpecialCharacterNode(tree.ParsedRootNode, SpecialCharacterType.NonBoundary);

			tree = RegexParser.ParseRegex(@"\d");
			this.VerifySpecialCharacterNode(tree.ParsedRootNode, SpecialCharacterType.Digit);

			tree = RegexParser.ParseRegex(@"\D");
			this.VerifySpecialCharacterNode(tree.ParsedRootNode, SpecialCharacterType.NonDigit);

			tree = RegexParser.ParseRegex(@"\s");
			this.VerifySpecialCharacterNode(tree.ParsedRootNode, SpecialCharacterType.WhiteSpace);

			tree = RegexParser.ParseRegex(@"\S");
			this.VerifySpecialCharacterNode(tree.ParsedRootNode, SpecialCharacterType.NonWhiteSpace);

			tree = RegexParser.ParseRegex(@"\w");
			this.VerifySpecialCharacterNode(tree.ParsedRootNode, SpecialCharacterType.Word);

			tree = RegexParser.ParseRegex(@"\W");
			this.VerifySpecialCharacterNode(tree.ParsedRootNode, SpecialCharacterType.NonWord);

			tree = RegexParser.ParseRegex(@"\G");
			this.VerifySpecialCharacterNode(tree.ParsedRootNode, SpecialCharacterType.EndOfPreviousMatch);

			tree = RegexParser.ParseRegex(@"\z");
			this.VerifySpecialCharacterNode(tree.ParsedRootNode, SpecialCharacterType.EndOfString);

			tree = RegexParser.ParseRegex(@"\Z");
			this.VerifySpecialCharacterNode(tree.ParsedRootNode, SpecialCharacterType.EndOfStringBeforeNewLine);
		}

		#endregion // SpecialCharacterTest

		#region ZeroOrMoreTest

		[TestMethod]
		public void ZeroOrMoreTest()
		{
			var tree = RegexParser.ParseRegex("a*");
			this.VerifyZeroOrMoreNode(tree.ParsedRootNode);
			this.VerifyCharacterNode(tree.ParsedRootNode[0], 'a');

			// For the first test, verify that the content child.
			var zeroOrMoreNode = (RegexZeroOrMoreNode)tree.ParsedRootNode;
			Assert.AreEqual(tree.ParsedRootNode[0], zeroOrMoreNode.Content, "The child is incorrect.");
		}

		#endregion // ZeroOrMoreTest

		#region ZeroOrOneTest

		[TestMethod]
		public void ZeroOrOneTest()
		{
			var tree = RegexParser.ParseRegex("a?");
			this.VerifyAlternationNode(tree.ParsedRootNode);
			this.VerifyCharacterNode(tree.ParsedRootNode[0], 'a');
			this.VerifyEmptyNode(tree.ParsedRootNode[1]);
		}

		#endregion // ZeroOrOneTest

		#endregion // Tests

		#region Private Methods

		#region VerifyAlternationNode

		private void VerifyAlternationNode(RegexNode node)
		{
			Assert.IsInstanceOfType(node, typeof(RegexAlternationNode), "Unexpected node type.");
			Assert.AreEqual(2, node.Count, "Incorrect child count.");

			var alternationNode = (RegexAlternationNode)node;
			Assert.AreEqual(node[0], alternationNode.Left, "The left child is incorrect.");
			Assert.AreEqual(node[1], alternationNode.Right, "The right child is incorrect.");
		}

		#endregion // VerifyAlternationNode

		#region VerifyCharacterCategoryNode

		private void VerifyCharacterCategoryNode(RegexNode node, string expectedCategory, bool expectedIsInclusive)
		{
			Assert.IsInstanceOfType(node, typeof(RegexCharacterCategoryNode), "Unexpected node type.");
			var characterCategoryNode = (RegexCharacterCategoryNode)node;
			Assert.AreEqual(expectedCategory, characterCategoryNode.CategoryName, "Incorrect category.");
			Assert.AreEqual(expectedIsInclusive, characterCategoryNode.IsInclusive, "Incorrect isInclusive.");
		}

		#endregion // VerifyCharacterCategoryNode

		#region VerifyCharacterNode

		private void VerifyCharacterNode(RegexNode node, char expectedChar)
		{
			Assert.IsInstanceOfType(node, typeof(RegexCharacterNode), "Unexpected node type.");
			var characterNode = (RegexCharacterNode)node;
			Assert.AreEqual(expectedChar, characterNode.Character, "Incorrect character.");
		}

		#endregion // VerifyCharacterNode

		#region VerifyCharacterRangeNode

		private void VerifyCharacterRangeNode(RegexNode node, char[] expectedChars)
		{
			Assert.IsInstanceOfType(node, typeof(RegexCharacterRangeNode), "Unexpected node type.");
			var characterRangeNode = (RegexCharacterRangeNode)node;
			Assert.AreEqual(expectedChars[0], characterRangeNode.FirstCharacter, "Incorrect first character.");
			Assert.AreEqual(expectedChars[1], characterRangeNode.LastCharacter, "Incorrect last character.");
		}

		#endregion // VerifyCharacterRangeNode

		#region VerifyCharacterSetNode

		private void VerifyCharacterSetNode(RegexNode node, bool isInclusive, params char[] expectedChars)
		{
			Assert.IsInstanceOfType(node, typeof(RegexCharacterSetNode), "Unexpected node type.");
			var characterSetNode = (RegexCharacterSetNode)node;
			Assert.AreEqual(expectedChars.Length, characterSetNode.Count, "Incorrect character count.");

			for (int i = 0; i < expectedChars.Length; i++)
				this.VerifyCharacterNode(characterSetNode[i], expectedChars[i]);
		}

		#endregion // VerifyCharacterSetNode

		#region VerifyCharacterSetRangeNode

		private void VerifyCharacterSetRangeNode(RegexNode node, bool isInclusive, params char[][] expectedChars)
		{
			Assert.IsInstanceOfType(node, typeof(RegexCharacterSetNode), "Unexpected node type.");
			var characterSetNode = (RegexCharacterSetNode)node;
			Assert.AreEqual(expectedChars.Length, characterSetNode.Count, "Incorrect character count.");

			for (int i = 0; i < expectedChars.Length; i++)
				this.VerifyCharacterRangeNode(characterSetNode[i], expectedChars[i]);
		}

		#endregion // VerifyCharacterSetRangeNode

		#region VerifyConcatenationNode

		private void VerifyConcatenationNode(RegexNode node)
		{
			Assert.IsInstanceOfType(node, typeof(RegexConcatenationNode), "Unexpected node type.");
			Assert.AreEqual(2, node.Count, "Incorrect child count.");

			var concatenationNode = (RegexConcatenationNode)node;
			Assert.AreEqual(node[0], concatenationNode.Left, "The left child is incorrect.");
			Assert.AreEqual(node[1], concatenationNode.Right, "The right child is incorrect.");
		}

		#endregion // VerifyConcatenationNode

		#region VerifyEmptyNode

		private void VerifyEmptyNode(RegexNode node)
		{
			Assert.IsInstanceOfType(node, typeof(RegexEmptyNode), "Unexpected node type.");
			Assert.AreEqual(0, node.Count, "Incorrect child count.");
		}

		#endregion // VerifyConcatenaVerifyEmptyNodetionNode

		#region VerifyErrorMessages

		private void VerifyErrorMessages(IEnumerable<string> errors, params string[] expectedErrors)
		{
			var errorList = errors.ToList();
			Assert.AreEqual(expectedErrors.Length, errorList.Count, "Incorrect number of errors.");

			for (int i = 0; i < expectedErrors.Length; i++)
				Assert.AreEqual(expectedErrors[i], errorList[i], "Incorrect error message.");
		}

		#endregion // VerifyErrorMessages

		#region VerifySpecialCharacterNode

		private void VerifySpecialCharacterNode(RegexNode node, SpecialCharacterType expectedCharacterType)
		{
			Assert.IsInstanceOfType(node, typeof(RegexSpecialCharacterNode), "Unexpected node type.");
			var specialCharacterNode = (RegexSpecialCharacterNode)node;
			Assert.AreEqual(expectedCharacterType, specialCharacterNode.CharacterType, "Incorrect character type.");
		}

		#endregion // VerifySpecialCharacterNode

		#region VerifyZeroOrMoreNode

		private void VerifyZeroOrMoreNode(RegexNode node)
		{
			Assert.IsInstanceOfType(node, typeof(RegexZeroOrMoreNode), "Unexpected node type.");
			Assert.AreEqual(1, node.Count, "Incorrect child count.");
		}

		#endregion // VerifyZeroOrMoreNode

		#endregion // Private Methods
	}
}
