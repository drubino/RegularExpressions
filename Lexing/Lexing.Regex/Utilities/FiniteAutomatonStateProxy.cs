using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexing.Regex;
using System.Diagnostics;

namespace Lexing.Regex
{
    /// <summary>
    /// A representation of a FiniteAutomatonState based on positions of RegexNodes.
    /// </summary>
    internal class FiniteAutomatonStateProxy
    {
        #region Fields

        private readonly SortedList<uint, RegexLeafNode> _positions = 
            new SortedList<uint,RegexLeafNode>();

        #endregion //Fields

        #region Properties

        public IEnumerable<RegexLeafNode> Positions
        {
            get { return _positions.Values; }
        }

        public bool IsAcceptorProxy
        {
            get { return this.Positions.Any(p => p.IsTerminalNode); }
        }

        public IEnumerable<string> Tokens
        {
            get 
            {
                return
                    from position in this.Positions
                    where position.IsTerminalNode
                    let terminalPosition = (RegexTerminalNode)position
                    select terminalPosition.Token;
            }
        }

        #endregion //Properties

        #region Constructors

        public FiniteAutomatonStateProxy(IEnumerable<RegexLeafNode> positions)
        {
            if (positions == null || !positions.Any())
                throw new ArgumentException("No positions were specified.");

            foreach (var position in positions)
                _positions.Add(position.Annotations.Position, position);
        }

        #endregion //Constructors

        #region Base Class Overrides

        #region Equals

        public override bool Equals(object obj)
        {
            return Equals(obj as FiniteAutomatonStateProxy);
        }

        public bool Equals(FiniteAutomatonStateProxy other)
        {
            if (other == null)
                return false;

            var count = _positions.Count;
            if (other._positions.Count != count)
                return false;

            var positions = _positions.Keys;
            var otherPositions = other._positions.Keys;

            for (int i = 0; i < count; i++)
            {
                if (positions[i] != otherPositions[i])
                    return false;
            }

            return true;
        }

        #endregion //Equals

        #region GetHashCode

        public override int GetHashCode()
        {
            var count = _positions.Count;
            var positions = _positions.Keys;

            if (count > 2)
                return
                    positions[0].GetHashCode() ^
                    positions[count - 1].GetHashCode() ^
                    positions[count / 2].GetHashCode();

            if (count == 2)
                return
                    positions[0].GetHashCode() ^
                    positions[count - 1].GetHashCode();

            if (count == 1)
                return
                    positions[0].GetHashCode();

            return 0;
        }

        #endregion //GetHashCode

        #region ToString

        public override string ToString()
        {
            var builder = new StringBuilder(10 * _positions.Count + 2);
            builder.Append('{');

            bool firstPass = true;
            foreach (var pair in _positions)
            {
                if (!firstPass)
                    builder.Append(", ");
                else
                    firstPass = false;

                builder.Append(pair.Key);
                builder.Append(": ");
                builder.Append(pair.Value);
            }
            builder.Append('}');

            return builder.ToString();
        }

        #endregion //ToString

        #endregion //Base Class Overrides

        #region Operators

        public static bool operator ==(FiniteAutomatonStateProxy first, FiniteAutomatonStateProxy second)
        {
            if (object.Equals(first, null))
                return object.Equals(second, null);

            return first.Equals(second);
        }

        public static bool operator !=(FiniteAutomatonStateProxy first, FiniteAutomatonStateProxy second)
        {
            return !(first == second);
        }

        #endregion //Operators
    }
}
