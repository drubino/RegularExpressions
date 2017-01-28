using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexing;

namespace Lexing
{
    internal sealed class PositionAnnotator : RegexSyntaxTreeVisitor
    {
        #region Fields

        PositionDispenser _positionDispenser;

        #endregion //Fields

        #region Constructor

        public PositionAnnotator(PositionDispenser positionDispenser)
        {
            if (positionDispenser == null)
                throw new ArgumentNullException("positionDispenser");

            _positionDispenser = positionDispenser;
        }

        #endregion //Constructor

        #region Base Class Overrides

        public override void VisitCharacterNode(RegexCharacterNode node)
        {
            AssignPosition(node);
        }

        public override void VisitCharacterSetNode(RegexCharacterSetNode node)
        {
            AssignPosition(node);
        }

        public override void VisitCharacterRangeNode(RegexCharacterRangeNode node)
        {
            AssignPosition(node);
        }

        public override void VisitCharacterCategoryNode(RegexCharacterCategoryNode node)
        {
            AssignPosition(node);
        }

        public override void VisitSpecialCharacterNode(RegexSpecialCharacterNode node)
        {
            AssignPosition(node);
        }

        public override void VisitEmptyNode(RegexEmptyNode node)
        {
            AssignPosition(node);
        }

        public override void VisitTerminalNode(RegexTerminalNode node)
        {
            AssignPosition(node);
        }

        #endregion //Base Class Overrides

        #region Utilities

        private void AssignPosition(RegexLeafNode leaf)
        {
            leaf.Annotations.Position = _positionDispenser.GetNextPosition();
        }

        #endregion //Utilities
    }
}
