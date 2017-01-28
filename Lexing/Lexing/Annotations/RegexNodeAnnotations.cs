using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexing;

namespace Lexing
{
    /// <summary>
    /// Annotations for SyntaxNodes to allow a FiniteAutomaton 
    /// to be constructed directly from the tree.
    /// </summary>
    internal class RegexNodeAnnotations
    {
        #region Fields

        private readonly RegexNode _node;
        private HashSet<RegexLeafNode> _firstPositions = new HashSet<RegexLeafNode>();
        private HashSet<RegexLeafNode> _lastPositions = new HashSet<RegexLeafNode>();
        private HashSet<RegexLeafNode> _followPositions = new HashSet<RegexLeafNode>();

        #endregion //Fields

        #region Properties

        public uint Position { get; set; }

        #endregion //Properties

        #region Constructors

        public RegexNodeAnnotations(RegexNode node)
        {
            if (node == null)
                throw new ArgumentNullException("node");

            _node = node;
        }

        #endregion //Constructors

        #region Properties

        public bool IsNullable { get; set; }

        public IEnumerable<RegexLeafNode> FirstPositions
        {
            get { return _firstPositions; }
        }

        public IEnumerable<RegexLeafNode> LastPositions
        {
            get { return _lastPositions; }
        }

        public IEnumerable<RegexLeafNode> FollowPositions
        {
            get { return _followPositions; }
        }

        public RegexNode Node
        {
            get { return _node; }
        }

        #endregion //Properties

        #region Methods

        public void AddFirstPosition(RegexLeafNode state)
        {
            _firstPositions.Add(state);
        }

        public void AddLastPosition(RegexLeafNode state)
        {
            _lastPositions.Add(state);
        }

        public void AddFollowPosition(RegexLeafNode state)
        {
            _followPositions.Add(state);
        }

        public void AddFirstPositions(IEnumerable<RegexLeafNode> states)
        {
            _firstPositions.UnionWith(states);
        }

        public void AddLastPositions(IEnumerable<RegexLeafNode> states)
        {
            _lastPositions.UnionWith(states);
        }

        public void AddFollowPositions(IEnumerable<RegexLeafNode> states)
        {
            _followPositions.UnionWith(states);
        }

        #endregion //Methods
    }
}
