using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Lexing.Regex;

namespace Lexing.Regex
{
	internal sealed class RegexZeroOrMoreNode : RegexNode
	{
        #region Fields

        private readonly RegexNode _content;

        #endregion //Fields

        #region Properties

        public RegexNode Content
        {
            get { return _content; }
        }

        #endregion //Properties

        #region Constructors

        public RegexZeroOrMoreNode(RegexNode content)
        {
            _content = content;
        }

        #endregion //Constructors

        #region Base Class Overrides

        public sealed override int Count
        {
            get { return 1; }
        }

        public sealed override void Accept(RegexSyntaxTreeVisitor visitor)
        {
            visitor.VisitZeroOrMoreNode(this);
        }

        public sealed override RegexNode DeepClone()
        {
            return new RegexZeroOrMoreNode(_content.DeepClone());
        }

        public sealed override RegexNode this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return _content;
                    default:
                        Utilities.DebugFail("Index out of range.");
                        return null;
                }
            }
        }

        #endregion //Base Class Overrrides
	}
}