using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexing;

namespace Lexing
{
    internal sealed class NullableAnnotator : RegexSyntaxTreeVisitor
    {
        #region Base Class Overrides

        public override void VisitCharacterNode(RegexCharacterNode node)
        {
            SetNullability(node, false);
        }

        public override void  VisitSpecialCharacterNode(RegexSpecialCharacterNode node)
        {
            SetNullability(node, false);
        }

        public override void VisitCharacterCategoryNode(RegexCharacterCategoryNode node)
        {
            SetNullability(node, false);
        }

        public override void VisitCharacterSetNode(RegexCharacterSetNode node)
        {
            SetNullability(node, false);
        }

        public override void VisitCharacterRangeNode(RegexCharacterRangeNode node)
        {
            SetNullability(node, false);
        }

        public override void VisitEmptyNode(RegexEmptyNode node)
        {
            SetNullability(node, true);
        }

        public override void VisitZeroOrMoreNode(RegexZeroOrMoreNode node)
        {
            SetNullability(node, true);
        }

        public override void VisitAlternationNode(RegexAlternationNode node)
        {
            SetNullability(node, 
                node.Left.Annotations.IsNullable || 
                node.Right.Annotations.IsNullable);
        }

        public override void VisitConcatenationNode(RegexConcatenationNode node)
        {
            SetNullability(node,
                node.Left.Annotations.IsNullable &&
                node.Right.Annotations.IsNullable);
        }

        public override void  VisitTerminalNode(RegexTerminalNode node)
        {
            SetNullability(node, false);
        }

        #endregion //Base Class Overrides

        #region Utilities

        private void SetNullability(RegexNode node, bool isNullable)
        {
            node.Annotations.IsNullable = isNullable;
        }

        #endregion //Utilities
    }
}
