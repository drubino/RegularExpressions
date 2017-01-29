using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Lexing.Regex;

namespace Lexing.Regex
{
    /// <summary>
    /// A single state of a finite automaton.
    /// </summary>
    internal class FiniteAutomatonState : IEnumerable<FiniteAutomatonTransition>
    {
        #region Fields

        private readonly Dictionary<char, FiniteAutomatonState> _transitions = new Dictionary<char, FiniteAutomatonState>();
        private readonly List<SetStatePair> _setTransitions = new List<SetStatePair>();

        #endregion //Fields

        #region Properties

        public bool IsAcceptor { get; set; }
        public string Token { get; set; }

        #endregion //Properties

        #region IEnumerable Members

        public IEnumerator<FiniteAutomatonTransition> GetEnumerator()
        {
            foreach (var pair in _transitions)
                yield return new FiniteAutomatonTransition(pair.Key, pair.Value);

            foreach (var pair in _setTransitions)
                yield return new FiniteAutomatonTransition(pair.Set, pair.State);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return
                ((IEnumerable<FiniteAutomatonTransition>)this)
                .GetEnumerator();
        }

        #endregion //IEnumerable Members

        #region Methods

        #region TransitionOn

        public FiniteAutomatonState TransitionOn(char input)
        {
            FiniteAutomatonState state;
            if (!_transitions.TryGetValue(input, out state) && 
                _setTransitions.Any())
                state = SetTransitionOn(input);

            return state;
        }

        #endregion //TransitionOn

        #region MakeAcceptor

        public FiniteAutomatonState MakeAcceptor()
        {
            this.IsAcceptor = true;
            return this;
        }

        #endregion //MakeAcceptor

        #region AddTransition

        public FiniteAutomatonState AddTransition(char input, FiniteAutomatonState state)
        {
            if (state == null)
                throw new ArgumentNullException("state");

            _transitions.Add(input, state);
            return this;
        }

        public FiniteAutomatonState AddTransition(CharacterSet inputSet, FiniteAutomatonState state)
        {
            if (inputSet == null)
                throw new ArgumentNullException("inputSet");
            if (state == null)
                throw new ArgumentNullException("state");

            _setTransitions.Add(new SetStatePair(inputSet, state));

            return this;
        }

        #endregion //AddTransition

        #endregion //Methods

        #region Utilities

        private FiniteAutomatonState SetTransitionOn(char input)
        {
            foreach (var pair in _setTransitions)
                if (pair.Set.Contains(input))
                    return pair.State;

            return null;
        }

        #endregion //Utilities

        #region Nested Classes

        private struct SetStatePair
        {
            private readonly CharacterSet set;
            private readonly FiniteAutomatonState state;

            public CharacterSet Set
            {
                get { return this.set; }
            }

            public FiniteAutomatonState State
            {
                get { return this.state; }
            }

            public SetStatePair(CharacterSet set, FiniteAutomatonState state)
            {
                this.set = set;
                this.state = state;
            }
        }

        #endregion //Nested Classes
    }
}
