using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexing.Regex;

namespace Lexing.Regex
{
    internal sealed class FirstPositionAnnotator : RegexSyntaxTreeVisitor
    {
        #region Base Class Overrides

        public override void VisitCharacterNode(RegexCharacterNode node)
        {
            AddFirstPosition(node, node);
        }

        public override void VisitSpecialCharacterNode(RegexSpecialCharacterNode node)
        {
            AddFirstPosition(node, node);
        }

        public override void VisitCharacterCategoryNode(RegexCharacterCategoryNode node)
        {
            AddFirstPosition(node, node);
        }

        public override void VisitCharacterSetNode(RegexCharacterSetNode node)
        {
            AddFirstPosition(node, node);
        }

        public override void VisitCharacterRangeNode(RegexCharacterRangeNode node)
        {
            AddFirstPosition(node, node);
        }

        public override void VisitZeroOrMoreNode(RegexZeroOrMoreNode node)
        {
            AddFirstPositions(node, node.Content.Annotations.FirstPositions);
        }

        public override void VisitAlternationNode(RegexAlternationNode node)
        {
            AddFirstPositions(node,
                node.Left.Annotations.FirstPositions.Concat(
                node.Right.Annotations.FirstPositions));
        }

        public override void VisitConcatenationNode(RegexConcatenationNode node)
        {
            var firstPositions = node.Left.Annotations.FirstPositions;
            if (node.Left.Annotations.IsNullable)
                firstPositions =
                    firstPositions.Concat(
                    node.Right.Annotations.FirstPositions);

            AddFirstPositions(node, firstPositions);
        }

        public override void  VisitTerminalNode(RegexTerminalNode node)
        {
            AddFirstPosition(node, node);
        }

        #endregion //Base Class Overrides

        #region Utilities

        private void AddFirstPosition(RegexNode node, RegexLeafNode firstPosition)
        {
            node.Annotations.AddFirstPosition(firstPosition);
        }

        private void AddFirstPositions(RegexNode node, IEnumerable<RegexLeafNode> firstPositions)
        {
            node.Annotations.AddFirstPositions(firstPositions);
        }

        #endregion //Utilities
    }
}
