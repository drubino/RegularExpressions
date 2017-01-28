using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexing;

namespace Lexing
{
    internal sealed class FollowPositionAnnotator : RegexSyntaxTreeVisitor
    {
        #region Base Class Overrides

        public override void VisitZeroOrMoreNode(RegexZeroOrMoreNode node)
        {
            var firstPositions = node.Annotations.FirstPositions;
            foreach (var lastPosition in node.Annotations.LastPositions)
                lastPosition.Annotations.AddFollowPositions(firstPositions);
        }

        public override void VisitConcatenationNode(RegexConcatenationNode node)
        {
            var rightFirstPositions = node.Right.Annotations.FirstPositions;
            foreach (var leftLastPosition in node.Left.Annotations.LastPositions)
                leftLastPosition.Annotations.AddFollowPositions(rightFirstPositions);
        }

        #endregion //Base Class Overrides
    }
}
