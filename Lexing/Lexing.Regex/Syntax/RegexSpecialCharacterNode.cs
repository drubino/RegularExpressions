using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Lexing.Regex;

namespace Lexing.Regex
{
	internal sealed class RegexSpecialCharacterNode : RegexLeafNode
	{
        #region Fields

        private readonly SpecialCharacterType _characterType;

        #endregion //Fields

        #region Properties

        public SpecialCharacterType CharacterType
        {
            get { return _characterType; }
        }

        #endregion //Properties

        #region Constructors

        public RegexSpecialCharacterNode(SpecialCharacterType characterType)
        {
            _characterType = characterType;
        }

        #endregion //Constructors

        #region Base Class Overrides

        #region ToString

        public override string ToString()
        {
            return base.ToString() + ": " + _characterType;
        }

        #endregion //ToString

        #region Accept

        public sealed override void Accept(RegexSyntaxTreeVisitor visitor)
        {
            visitor.VisitSpecialCharacterNode(this);
        }

        #endregion //Accept

        #region DeepClone

        public sealed override RegexNode DeepClone()
        {
            return new RegexSpecialCharacterNode(_characterType);
        }

        #endregion //DeepClone

        #region ToCharacterSet

        public override CharacterSet ToCharacterSet()
        {
            var set = new CharacterSet();
            switch (this.CharacterType)
            {
                case SpecialCharacterType.Boundary:
                    set.AddCharacter('\u0008');
                    break;
                case SpecialCharacterType.Digit:
                    set.AddCategory("Nd");
                    break;
                case SpecialCharacterType.NonDigit:
                    set.AddCategory("Nd").MakeExclusive();
                    break;
                case SpecialCharacterType.WhiteSpace:
                    set.AddCharacters('\f', '\n', '\r', '\t', '\v', '\x85').AddCategory("Z");
                    break;
                case SpecialCharacterType.NonWhiteSpace:
                    set.AddCharacters('\f', '\n', '\r', '\t', '\v', '\x85').AddCategory("Z").MakeExclusive();
                    break;
                case SpecialCharacterType.Wildcard:
                    set.AddCharacter('\n').MakeExclusive();
                    break;
                case SpecialCharacterType.Word:
                    set.AddCategories("Ll", "Lu", "Lt", "Lo", "Lm", "Nd", "Pc");
                    break;
                case SpecialCharacterType.NonWord:
                    set.AddCategories("Ll", "Lu", "Lt", "Lo", "Lm", "Nd", "Pc").MakeExclusive();
                    break;
                case SpecialCharacterType.NonBoundary:
                    throw new NotSupportedException("Non-word boundary matching is not supported.");
                case SpecialCharacterType.EndOfLine:
                    throw new NotSupportedException("End of line matching is not supported.");
                case SpecialCharacterType.EndOfPreviousMatch:
                    throw new NotSupportedException("End of previous matching is not supported.");
                case SpecialCharacterType.EndOfString:
                    throw new NotSupportedException("End of string matching is not supported.");
                case SpecialCharacterType.EndOfStringBeforeNewLine:
                    throw new NotSupportedException("End of string before new line matching is not supported.");
                case SpecialCharacterType.StartOfLine:
                    throw new NotSupportedException("Start of line matching is not supported.");
                case SpecialCharacterType.StartOfString:
                    throw new NotSupportedException("Start of string matching is not supported.");
                default:
                    throw new InvalidOperationException("The special character was not recognized.");
            }

            return set;
        }

        #endregion //ToCharacterSet

        #endregion //Base Class Overrides

        #region StaticMembers

        public static SpecialCharacterType? ParseEscapedSpecialCharacterType(char escapedCharacter)
        {
            switch (escapedCharacter)
            {
                case 'A': return SpecialCharacterType.StartOfString;
                case 'b': return SpecialCharacterType.Boundary;
                case 'B': return SpecialCharacterType.NonBoundary;
                case 'd': return SpecialCharacterType.Digit;
                case 'D': return SpecialCharacterType.NonDigit;
                case 's': return SpecialCharacterType.WhiteSpace;
                case 'S': return SpecialCharacterType.NonWhiteSpace;
                case 'w': return SpecialCharacterType.Word;
                case 'W': return SpecialCharacterType.NonWord;
                case 'G': return SpecialCharacterType.EndOfPreviousMatch;
                case 'z': return SpecialCharacterType.EndOfString;
                case 'Z': return SpecialCharacterType.EndOfStringBeforeNewLine;

                default:
                    return null;
            }
        }

        #endregion //StaticMembers
	}

    #region SpecialCharacterType

	public enum SpecialCharacterType
	{
		StartOfString,				// \A
		Boundary,					// \b
		NonBoundary,				// \B
		Digit,						// \d
		NonDigit,					// \D
		WhiteSpace,					// \s
		NonWhiteSpace,				// \S
		Word,						// \w
		NonWord,					// \W
		EndOfPreviousMatch,			// \G
		EndOfString,				// \z
		EndOfStringBeforeNewLine,	// \Z

		Wildcard,					// .
		StartOfLine,				// ^
		EndOfLine,					// $
	}

    #endregion //SpecialCharacterType
}