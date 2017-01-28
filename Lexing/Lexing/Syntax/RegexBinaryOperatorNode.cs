using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Lexing;

namespace Lexing
{
    internal abstract class RegexBinaryOperatorNode : RegexNode
	{
        #region Fields

        private readonly RegexNode _left;
        private readonly RegexNode _right;

        #endregion //Fields

        #region Properties

        public RegexNode Left
        {
            get { return _left; }
        }

        public RegexNode Right
        {
            get { return _right; }
        }

        #endregion //Properties

        #region Constructors

        public RegexBinaryOperatorNode(RegexNode left, RegexNode right)
        {
            _left = left;
            _right = right;
        }

        #endregion //Constructors

        #region Base Class Overrides

        public sealed override int Count
        {
            get { return 2; }
        }

        public sealed override RegexNode this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return _left;
                    case 1: return _right;
                    default:
                        Utilities.DebugFail("Index out of range.");
                        return null;
                }
            }
        }

        #endregion //Base Class Overrides
	}
}