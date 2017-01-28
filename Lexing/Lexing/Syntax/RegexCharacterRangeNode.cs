using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Lexing;

namespace Lexing
{
	internal sealed class RegexCharacterRangeNode : RegexLeafNode
	{
        #region Fields

        private readonly char _firstCharacter;
        private readonly char _lastCharacter;

        #endregion //Fields

        #region Properties

        public char FirstCharacter
        {
            get { return _firstCharacter; }
        }

        public char LastCharacter
        {
            get { return _lastCharacter; }
        }

        #endregion //Properties

        #region Constructors

        public RegexCharacterRangeNode(char firstCharacter, char lastCharacter)
        {
            _firstCharacter = firstCharacter;
            _lastCharacter = lastCharacter;
        }

        #endregion //Constructors

        #region Base Class Overrides

        public sealed override void Accept(RegexSyntaxTreeVisitor visitor)
        {
            visitor.VisitCharacterRangeNode(this);
        }

		public sealed override RegexNode DeepClone()
		{
			return new RegexCharacterRangeNode(_firstCharacter, _lastCharacter);
		}

		public override string ToString()
		{
			return base.ToString() + ": " + _firstCharacter + "-" + _lastCharacter;
        }

        public override CharacterSet ToCharacterSet()
        {
            return
                new CharacterSet()
                .AddRange(this.FirstCharacter, this.LastCharacter);
        }

        #endregion //Base Class Overrides
    }
}