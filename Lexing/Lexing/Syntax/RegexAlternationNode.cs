using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Lexing;

namespace Lexing
{
	internal sealed class RegexAlternationNode : RegexBinaryOperatorNode
	{
        #region Constructors

        public RegexAlternationNode(RegexNode left, RegexNode right) : base(left, right) { }

        #endregion //Constructors

        #region Base Class Overrides

        public sealed override void Accept(RegexSyntaxTreeVisitor visitor)
        {
            visitor.VisitAlternationNode(this);
        }

		public sealed override RegexNode DeepClone()
		{
			return new RegexAlternationNode(this.Left.DeepClone(), this.Right.DeepClone());
        }

        #endregion //Base Class Overrides
    }
}