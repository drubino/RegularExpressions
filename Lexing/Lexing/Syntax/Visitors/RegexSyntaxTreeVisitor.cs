using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexing
{
    internal abstract class RegexSyntaxTreeVisitor
    {
        protected virtual void DefaultVisit(RegexNode node) { }

        protected virtual void VisitChildren(RegexNode node)
        {
            foreach (var child in node)
                child.Accept(this);
        }

        public virtual void VisitAlternationNode(RegexAlternationNode node)
        {
            DefaultVisit(node);
        }

        public virtual void VisitCharacterCategoryNode(RegexCharacterCategoryNode node)
        {
            DefaultVisit(node);
        }

        public virtual void VisitCharacterNode(RegexCharacterNode node)
        {
            DefaultVisit(node);
        }

        public virtual void VisitCharacterRangeNode(RegexCharacterRangeNode node)
        {
            DefaultVisit(node);
        }

        public virtual void VisitCharacterSetNode(RegexCharacterSetNode node)
        {
            DefaultVisit(node);
        }

        public virtual void VisitConcatenationNode(RegexConcatenationNode node)
        {
            DefaultVisit(node);
        }

        public virtual void VisitEmptyNode(RegexEmptyNode node)
        {
            DefaultVisit(node);
        }

        public virtual void VisitSpecialCharacterNode(RegexSpecialCharacterNode node)
        {
            DefaultVisit(node);
        }

        public virtual void VisitZeroOrMoreNode(RegexZeroOrMoreNode node)
        {
            DefaultVisit(node);
        }

        public virtual void VisitTerminalNode(RegexTerminalNode node)
        {
            DefaultVisit(node);
        }
    }
}
