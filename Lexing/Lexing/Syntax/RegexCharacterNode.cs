using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Lexing;

namespace Lexing
{
    internal sealed class RegexCharacterNode : RegexLeafNode
	{
		private readonly char _character;

        public char Character
        {
            get { return _character; }
        }

		public RegexCharacterNode(char character)
		{
			_character = character;
		}

        public override string ToString()
        {
            return base.ToString() + ": " + _character;
        }

        public sealed override void Accept(RegexSyntaxTreeVisitor visitor)
        {
            visitor.VisitCharacterNode(this);
        }

		public sealed override RegexNode DeepClone()
		{
			return new RegexCharacterNode(_character);
		}

        public override CharacterSet ToCharacterSet()
        {
            return 
                new CharacterSet()
                .AddCharacter(this.Character);
        }
	}
}