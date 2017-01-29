using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Lexing.Regex;

namespace Lexing.Regex
{
    internal sealed class RegexConcatenationNode : RegexBinaryOperatorNode
	{
		public RegexConcatenationNode(RegexNode left, RegexNode right)
			: base(left, right) { }

        public sealed override void Accept(RegexSyntaxTreeVisitor visitor)
        {
            visitor.VisitConcatenationNode(this);
        }

		public sealed override RegexNode DeepClone()
		{
			return new RegexConcatenationNode(this.Left.DeepClone(), this.Right.DeepClone());
		}
	}
}