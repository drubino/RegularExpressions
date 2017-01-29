using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Lexing.Regex;

namespace Lexing.Regex
{
    internal sealed class RegexCharacterSetNode : RegexLeafNode
	{
        #region Fields

        private readonly RegexLeafNode[] _characters;
        private readonly bool _isInclusive;

        #endregion //Fields

        #region Properties

        public RegexLeafNode[] Characters
        {
            get { return _characters; }
        }

        public bool IsInclusive
        {
            get { return _isInclusive; }
        }

        #endregion //Properties

        #region Constructors

        public RegexCharacterSetNode(RegexLeafNode[] characters, bool isInclusive)
        {
            _characters = characters;
            _isInclusive = isInclusive;
        }

        #endregion //Constructors

        #region Base Class Overrides

		public sealed override int Count
		{
			get { return _characters.Length; }
		}

        public sealed override void Accept(RegexSyntaxTreeVisitor visitor)
        {
            visitor.VisitCharacterSetNode(this);
        }

		public sealed override RegexNode DeepClone()
		{
			return new RegexCharacterSetNode(_characters, _isInclusive);
		}

		public sealed override RegexNode this[int index]
		{
			get { return _characters[index]; }
        }

        public override CharacterSet ToCharacterSet()
        {
            var builder = new CharacterSetBuilder();
            Accept(builder);

            return builder.ToCharacterSet();

        }

        #endregion //Base Class Overrides
    }
}