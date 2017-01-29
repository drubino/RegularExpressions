using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexing.Regex;
using Lexing.Regex.Syntax.Visitors;

namespace Lexing.Regex
{
    internal class RegexSyntaxTreeVisitorCombinator : RegexSyntaxTreeWalker
    {
        #region Fields

        private bool _topDownWalk;
        private RegexSyntaxTreeVisitor[] _visitors;

        #endregion //Fields

        #region Constructors

        public RegexSyntaxTreeVisitorCombinator(TreeWalkingOptions options, params RegexSyntaxTreeVisitor[] visitors)
            : this(options, (IEnumerable<RegexSyntaxTreeVisitor>)visitors) { }

        public RegexSyntaxTreeVisitorCombinator(TreeWalkingOptions options, IEnumerable<RegexSyntaxTreeVisitor> visitors)
        {
            if (visitors == null)
                throw new ArgumentNullException("visitors");

            _topDownWalk = options == TreeWalkingOptions.TopDown;
            _visitors = visitors.ToArray();
        }

        #endregion //Constructors

        #region Base Class Overrides

        protected override void DefaultVisit(RegexNode node)
        {
            if (_topDownWalk)
                InvokeVisitors(node);

            base.DefaultVisit(node);

            if (!_topDownWalk)
                InvokeVisitors(node);
        }

        #endregion //Base Class Overrides

        #region Methods

        #region InvokeVisitors

        private void InvokeVisitors(RegexNode node)
        {
            foreach (var visitor in _visitors)
                node.Accept(visitor);
        }

        #endregion //InvokeVisitors

        #endregion //Methods
    }

    #region TreeWalkingOptions

    public enum TreeWalkingOptions
    { 
        //A breadth first search, starting at the root.
        TopDown,

        //A breadth first search starting at the leaves.
        BottomUp
    }

    #endregion //TreeWalkingOptions
}
