using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Lexing;
using Infragistics.Documents.Parsing;

namespace Lexing
{
	public abstract class RegexConcreteTreeVisitor<TResult>
    {
        public const string AlternationExpressionSymbolName = "AlternationExpression";
        public const string AsteriskTokenSymbolName = "AsteriskToken";
        public const string BackreferenceTokenSymbolName = "BackreferenceToken";
        public const string BalancingGroupExpressionSymbolName = "BalancingGroupExpression";
        public const string BarTokenSymbolName = "BarToken";
        public const string BracedQuantifierExpressionSymbolName = "BracedQuantifierExpression";
        public const string BracedQuantifierLazyExpressionSymbolName = "BracedQuantifierLazyExpression";
        public const string BracedQuantifierQuestionMarkTokenSymbolName = "BracedQuantifierQuestionMarkToken";
        public const string BracedQuantifierTokenSymbolName = "BracedQuantifierToken";
        public const string CaretTokenSymbolName = "CaretToken";
        public const string CharacterSymbolName = "Character";
        public const string CharacterCategoryTokenSymbolName = "CharacterCategoryToken";
        public const string CharacterExclusionSetSymbolName = "CharacterExclusionSet";
        public const string CharacterInSetSymbolName = "CharacterInSet";
        public const string CharacterRangeSymbolName = "CharacterRange";
        public const string CharacterSetSymbolName = "CharacterSet";
        public const string CloseBracketTokenSymbolName = "CloseBracketToken";
        public const string CloseParenTokenSymbolName = "CloseParenToken";
        public const string ColonTokenSymbolName = "ColonToken";
        public const string ConcatenationExpressionSymbolName = "ConcatenationExpression";
        public const string ConditionalExpressionSymbolName = "ConditionalExpression";
        public const string ControlCharacterTokenSymbolName = "ControlCharacterToken";
        public const string DollarSignTokenSymbolName = "DollarSignToken";
        public const string DotTokenSymbolName = "DotToken";
        public const string EmptyExpressionSymbolName = "EmptyExpression";
        public const string EndingEscapeErrorSymbolName = "EndingEscapeError";
        public const string EndOfFileTokenSymbolName = "EndOfFileToken";
        public const string EqualsTokenSymbolName = "EqualsToken";
        public const string EscapedCharacterTokenSymbolName = "EscapedCharacterToken";
        public const string ExclamationPointTokenSymbolName = "ExclamationPointToken";
        public const string GreaterThanTokenSymbolName = "GreaterThanToken";
        public const string GroupNameSymbolName = "GroupName";
        public const string HexadecimalCharacterTokenSymbolName = "HexadecimalCharacterToken";
        public const string LessThanTokenSymbolName = "LessThanToken";
        public const string MinusTokenSymbolName = "MinusToken";
        public const string MultiLineCommentSymbolName = "MultiLineComment";
        public const string NamedBackreferenceTokenSymbolName = "NamedBackreferenceToken";
        public const string NamedGroupExpressionSymbolName = "NamedGroupExpression";
        public const string NegativeLookaheadExpressionSymbolName = "NegativeLookaheadExpression";
        public const string NegativeLookbehindExpressionSymbolName = "NegativeLookbehindExpression";
        public const string NonBacktrackingExpressionSymbolName = "NonBacktrackingExpression";
        public const string NonCapturingGroupExpressionSymbolName = "NonCapturingGroupExpression";
        public const string OctalCharacterTokenSymbolName = "OctalCharacterToken";
        public const string OneOrMoreExpressionSymbolName = "OneOrMoreExpression";
        public const string OneOrMoreLazyExpressionSymbolName = "OneOrMoreLazyExpression";
        public const string OpenBracketTokenSymbolName = "OpenBracketToken";
        public const string OpenParenTokenSymbolName = "OpenParenToken";
        public const string OptionGlobalExpressionSymbolName = "OptionGlobalExpression";
        public const string OptionGlobalExpressionsSymbolName = "OptionGlobalExpressions";
        public const string OptionLocalExpressionSymbolName = "OptionLocalExpression";
        public const string OptionsSetSymbolName = "OptionsSet";
        public const string OptionsSpecifierSymbolName = "OptionsSpecifier";
        public const string ParenthesizedExpressionSymbolName = "ParenthesizedExpression";
        public const string PlusTokenSymbolName = "PlusToken";
        public const string PositiveLookaheadExpressionSymbolName = "PositiveLookaheadExpression";
        public const string PositiveLookbehindExpressionSymbolName = "PositiveLookbehindExpression";
        public const string QuestionMarkTokenSymbolName = "QuestionMarkToken";
        public const string RegexPatternSymbolName = "RegexPattern";
        public const string SingleLineCommentSymbolName = "SingleLineComment";
        public const string UnescapedCharacterTokenSymbolName = "UnescapedCharacterToken";
        public const string UnicodeCharacterTokenSymbolName = "UnicodeCharacterToken";
        public const string ZeroOrMoreExpressionSymbolName = "ZeroOrMoreExpression";
        public const string ZeroOrMoreLazyExpressionSymbolName = "ZeroOrMoreLazyExpression";
        public const string ZeroOrOneExpressionSymbolName = "ZeroOrOneExpression";
        public const string ZeroOrOneLazyExpressionSymbolName = "ZeroOrOneLazyExpression";

        public virtual TResult DefaultVisit(SyntaxNode node)
        {
            return default (TResult);
        }

        public virtual TResult VisitAlternationExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitAsteriskToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitBackreferenceToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitBalancingGroupExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitBarToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitBracedQuantifierExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitBracedQuantifierLazyExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitBracedQuantifierQuestionMarkToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitBracedQuantifierToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitCaretToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitCharacter(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitCharacterCategoryToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitCharacterExclusionSet(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitCharacterInSet(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitCharacterRange(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitCharacterSet(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitCloseBracketToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitCloseParenToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitColonToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitConcatenationExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitConditionalExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitControlCharacterToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitDollarSignToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitDotToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitEmptyExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitEndingEscapeError(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitEndOfFileToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitEqualsToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitEscapedCharacterToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitExclamationPointToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitGreaterThanToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitGroupName(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitHexadecimalCharacterToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitLessThanToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitMinusToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitMultiLineComment(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitNamedBackreferenceToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitNamedGroupExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitNegativeLookaheadExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitNegativeLookbehindExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitNonBacktrackingExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitNonCapturingGroupExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitOctalCharacterToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitOneOrMoreExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitOneOrMoreLazyExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitOpenBracketToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitOpenParenToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitOptionGlobalExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitOptionGlobalExpressions(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitOptionLocalExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitOptionsSet(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitOptionsSpecifier(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitParenthesizedExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitPlusToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitPositiveLookaheadExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitPositiveLookbehindExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitQuestionMarkToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitRegexPattern(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitSingleLineComment(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitUnescapedCharacterToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitUnicodeCharacterToken(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitZeroOrMoreExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitZeroOrMoreLazyExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitZeroOrOneExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }

        public virtual TResult VisitZeroOrOneLazyExpression(SyntaxNode node)
        {
            return this.DefaultVisit(node);
        }
    }

    internal static class RegexConcreteTreeExtensions
    {
        public static TResult Accept<TResult>(this SyntaxNode node, RegexConcreteTreeVisitor<TResult> visitor)
        {
            switch (node.Symbol.Name)
            {
                case RegexConcreteTreeVisitor<TResult>.AlternationExpressionSymbolName:
                    return visitor.VisitAlternationExpression(node);
                case RegexConcreteTreeVisitor<TResult>.AsteriskTokenSymbolName:
                    return visitor.VisitAsteriskToken(node);
                case RegexConcreteTreeVisitor<TResult>.BackreferenceTokenSymbolName:
                    return visitor.VisitBackreferenceToken(node);
                case RegexConcreteTreeVisitor<TResult>.BalancingGroupExpressionSymbolName:
                    return visitor.VisitBalancingGroupExpression(node);
                case RegexConcreteTreeVisitor<TResult>.BarTokenSymbolName:
                    return visitor.VisitBarToken(node);
                case RegexConcreteTreeVisitor<TResult>.BracedQuantifierExpressionSymbolName:
                    return visitor.VisitBracedQuantifierExpression(node);
                case RegexConcreteTreeVisitor<TResult>.BracedQuantifierLazyExpressionSymbolName:
                    return visitor.VisitBracedQuantifierLazyExpression(node);
                case RegexConcreteTreeVisitor<TResult>.BracedQuantifierQuestionMarkTokenSymbolName:
                    return visitor.VisitBracedQuantifierQuestionMarkToken(node);
                case RegexConcreteTreeVisitor<TResult>.BracedQuantifierTokenSymbolName:
                    return visitor.VisitBracedQuantifierToken(node);
                case RegexConcreteTreeVisitor<TResult>.CaretTokenSymbolName:
                    return visitor.VisitCaretToken(node);
                case RegexConcreteTreeVisitor<TResult>.CharacterSymbolName:
                    return visitor.VisitCharacter(node);
                case RegexConcreteTreeVisitor<TResult>.CharacterCategoryTokenSymbolName:
                    return visitor.VisitCharacterCategoryToken(node);
                case RegexConcreteTreeVisitor<TResult>.CharacterExclusionSetSymbolName:
                    return visitor.VisitCharacterExclusionSet(node);
                case RegexConcreteTreeVisitor<TResult>.CharacterInSetSymbolName:
                    return visitor.VisitCharacterInSet(node);
                case RegexConcreteTreeVisitor<TResult>.CharacterRangeSymbolName:
                    return visitor.VisitCharacterRange(node);
                case RegexConcreteTreeVisitor<TResult>.CharacterSetSymbolName:
                    return visitor.VisitCharacterSet(node);
                case RegexConcreteTreeVisitor<TResult>.CloseBracketTokenSymbolName:
                    return visitor.VisitCloseBracketToken(node);
                case RegexConcreteTreeVisitor<TResult>.CloseParenTokenSymbolName:
                    return visitor.VisitCloseParenToken(node);
                case RegexConcreteTreeVisitor<TResult>.ColonTokenSymbolName:
                    return visitor.VisitColonToken(node);
                case RegexConcreteTreeVisitor<TResult>.ConcatenationExpressionSymbolName:
                    return visitor.VisitConcatenationExpression(node);
                case RegexConcreteTreeVisitor<TResult>.ConditionalExpressionSymbolName:
                    return visitor.VisitConditionalExpression(node);
                case RegexConcreteTreeVisitor<TResult>.ControlCharacterTokenSymbolName:
                    return visitor.VisitControlCharacterToken(node);
                case RegexConcreteTreeVisitor<TResult>.DollarSignTokenSymbolName:
                    return visitor.VisitDollarSignToken(node);
                case RegexConcreteTreeVisitor<TResult>.DotTokenSymbolName:
                    return visitor.VisitDotToken(node);
                case RegexConcreteTreeVisitor<TResult>.EmptyExpressionSymbolName:
                    return visitor.VisitEmptyExpression(node);
                case RegexConcreteTreeVisitor<TResult>.EndingEscapeErrorSymbolName:
                    return visitor.VisitEndingEscapeError(node);
                case RegexConcreteTreeVisitor<TResult>.EndOfFileTokenSymbolName:
                    return visitor.VisitEndOfFileToken(node);
                case RegexConcreteTreeVisitor<TResult>.EqualsTokenSymbolName:
                    return visitor.VisitEqualsToken(node);
                case RegexConcreteTreeVisitor<TResult>.EscapedCharacterTokenSymbolName:
                    return visitor.VisitEscapedCharacterToken(node);
                case RegexConcreteTreeVisitor<TResult>.ExclamationPointTokenSymbolName:
                    return visitor.VisitExclamationPointToken(node);
                case RegexConcreteTreeVisitor<TResult>.GreaterThanTokenSymbolName:
                    return visitor.VisitGreaterThanToken(node);
                case RegexConcreteTreeVisitor<TResult>.GroupNameSymbolName:
                    return visitor.VisitGroupName(node);
                case RegexConcreteTreeVisitor<TResult>.HexadecimalCharacterTokenSymbolName:
                    return visitor.VisitHexadecimalCharacterToken(node);
                case RegexConcreteTreeVisitor<TResult>.LessThanTokenSymbolName:
                    return visitor.VisitLessThanToken(node);
                case RegexConcreteTreeVisitor<TResult>.MinusTokenSymbolName:
                    return visitor.VisitMinusToken(node);
                case RegexConcreteTreeVisitor<TResult>.MultiLineCommentSymbolName:
                    return visitor.VisitMultiLineComment(node);
                case RegexConcreteTreeVisitor<TResult>.NamedBackreferenceTokenSymbolName:
                    return visitor.VisitNamedBackreferenceToken(node);
                case RegexConcreteTreeVisitor<TResult>.NamedGroupExpressionSymbolName:
                    return visitor.VisitNamedGroupExpression(node);
                case RegexConcreteTreeVisitor<TResult>.NegativeLookaheadExpressionSymbolName:
                    return visitor.VisitNegativeLookaheadExpression(node);
                case RegexConcreteTreeVisitor<TResult>.NegativeLookbehindExpressionSymbolName:
                    return visitor.VisitNegativeLookbehindExpression(node);
                case RegexConcreteTreeVisitor<TResult>.NonBacktrackingExpressionSymbolName:
                    return visitor.VisitNonBacktrackingExpression(node);
                case RegexConcreteTreeVisitor<TResult>.NonCapturingGroupExpressionSymbolName:
                    return visitor.VisitNonCapturingGroupExpression(node);
                case RegexConcreteTreeVisitor<TResult>.OctalCharacterTokenSymbolName:
                    return visitor.VisitOctalCharacterToken(node);
                case RegexConcreteTreeVisitor<TResult>.OneOrMoreExpressionSymbolName:
                    return visitor.VisitOneOrMoreExpression(node);
                case RegexConcreteTreeVisitor<TResult>.OneOrMoreLazyExpressionSymbolName:
                    return visitor.VisitOneOrMoreLazyExpression(node);
                case RegexConcreteTreeVisitor<TResult>.OpenBracketTokenSymbolName:
                    return visitor.VisitOpenBracketToken(node);
                case RegexConcreteTreeVisitor<TResult>.OpenParenTokenSymbolName:
                    return visitor.VisitOpenParenToken(node);
                case RegexConcreteTreeVisitor<TResult>.OptionGlobalExpressionSymbolName:
                    return visitor.VisitOptionGlobalExpression(node);
                case RegexConcreteTreeVisitor<TResult>.OptionGlobalExpressionsSymbolName:
                    return visitor.VisitOptionGlobalExpressions(node);
                case RegexConcreteTreeVisitor<TResult>.OptionLocalExpressionSymbolName:
                    return visitor.VisitOptionLocalExpression(node);
                case RegexConcreteTreeVisitor<TResult>.OptionsSetSymbolName:
                    return visitor.VisitOptionsSet(node);
                case RegexConcreteTreeVisitor<TResult>.OptionsSpecifierSymbolName:
                    return visitor.VisitOptionsSpecifier(node);
                case RegexConcreteTreeVisitor<TResult>.ParenthesizedExpressionSymbolName:
                    return visitor.VisitParenthesizedExpression(node);
                case RegexConcreteTreeVisitor<TResult>.PlusTokenSymbolName:
                    return visitor.VisitPlusToken(node);
                case RegexConcreteTreeVisitor<TResult>.PositiveLookaheadExpressionSymbolName:
                    return visitor.VisitPositiveLookaheadExpression(node);
                case RegexConcreteTreeVisitor<TResult>.PositiveLookbehindExpressionSymbolName:
                    return visitor.VisitPositiveLookbehindExpression(node);
                case RegexConcreteTreeVisitor<TResult>.QuestionMarkTokenSymbolName:
                    return visitor.VisitQuestionMarkToken(node);
                case RegexConcreteTreeVisitor<TResult>.RegexPatternSymbolName:
                    return visitor.VisitRegexPattern(node);
                case RegexConcreteTreeVisitor<TResult>.SingleLineCommentSymbolName:
                    return visitor.VisitSingleLineComment(node);
                case RegexConcreteTreeVisitor<TResult>.UnescapedCharacterTokenSymbolName:
                    return visitor.VisitUnescapedCharacterToken(node);
                case RegexConcreteTreeVisitor<TResult>.UnicodeCharacterTokenSymbolName:
                    return visitor.VisitUnicodeCharacterToken(node);
                case RegexConcreteTreeVisitor<TResult>.ZeroOrMoreExpressionSymbolName:
                    return visitor.VisitZeroOrMoreExpression(node);
                case RegexConcreteTreeVisitor<TResult>.ZeroOrMoreLazyExpressionSymbolName:
                    return visitor.VisitZeroOrMoreLazyExpression(node);
                case RegexConcreteTreeVisitor<TResult>.ZeroOrOneExpressionSymbolName:
                    return visitor.VisitZeroOrOneExpression(node);
                case RegexConcreteTreeVisitor<TResult>.ZeroOrOneLazyExpressionSymbolName:
                    return visitor.VisitZeroOrOneLazyExpression(node);
                default:
                    Utilities.DebugFail("Unknown symbol name: " + node.Symbol.Name);
                    return default (TResult);
            }
        }
    }
}