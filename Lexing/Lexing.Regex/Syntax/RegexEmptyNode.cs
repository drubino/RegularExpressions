using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Lexing.Regex;

namespace Lexing.Regex
{
	// TODO_CTP: Can this be singleton?
    internal sealed class RegexEmptyNode : RegexLeafNode
	{
		public RegexEmptyNode() { }

        public sealed override void Accept(RegexSyntaxTreeVisitor visitor)
        {
            visitor.VisitEmptyNode(this);
        }

		public sealed override RegexNode DeepClone()
		{
			// TODO_CTP: If this is a singleton, don't create a new one here.
			return new RegexEmptyNode();
		}

        public override CharacterSet ToCharacterSet()
        {
            return new CharacterSet();
        }
	}
}