using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexing.Regex;

namespace Lexing.Regex
{
    internal sealed class LastPositionAnnotator : RegexSyntaxTreeVisitor
    {
        #region Base Class Overrides

        public override void VisitCharacterNode(RegexCharacterNode node)
        {
            AddLastPosition(node, node);
        }

        public override void VisitSpecialCharacterNode(RegexSpecialCharacterNode node)
        {
            AddLastPosition(node, node);
        }

        public override void VisitCharacterCategoryNode(RegexCharacterCategoryNode node)
        {
            AddLastPosition(node, node);
        }

        public override void VisitCharacterSetNode(RegexCharacterSetNode node)
        {
            AddLastPosition(node, node);
        }

        public override void VisitCharacterRangeNode(RegexCharacterRangeNode node)
        {
            AddLastPosition(node, node);
        }

        public override void VisitZeroOrMoreNode(RegexZeroOrMoreNode node)
        {
            AddLastPositions(node, node.Content.Annotations.LastPositions);
        }

        public override void VisitAlternationNode(RegexAlternationNode node)
        {
            AddLastPositions(node,
                node.Left.Annotations.LastPositions.Concat(
                node.Right.Annotations.LastPositions));
        }

        public override void VisitConcatenationNode(RegexConcatenationNode node)
        {
            var lastPositions = node.Right.Annotations.LastPositions;
            if (node.Right.Annotations.IsNullable)
                lastPositions =
                    lastPositions.Concat(
                    node.Left.Annotations.LastPositions);

            AddLastPositions(node, lastPositions);
        }

        public override void VisitTerminalNode(RegexTerminalNode node)
        {
            AddLastPosition(node, node);
        }

        #endregion //Base Class Overrides

        #region Utilities

        private void AddLastPosition(RegexNode node, RegexLeafNode firstPosition)
        {
            node.Annotations.AddLastPosition(firstPosition);
        }

        private void AddLastPositions(RegexNode node, IEnumerable<RegexLeafNode> firstPositions)
        {
            node.Annotations.AddLastPositions(firstPositions);
        }

        #endregion //Utilities
    }
}
