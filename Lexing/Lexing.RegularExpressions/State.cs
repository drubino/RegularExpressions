using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexing.RegularExpressions
{
    internal class State
    {
        #region Fields

        private CharacterSet characterSet;
        private HashSet<State> nextStates = new HashSet<State>();
        private IEnumerable<State> emptyStates;

        #endregion //Fields

        #region Properties

        public bool IsAcceptor { get; set; }
        public HashSet<State> NextStates { get { return this.nextStates; } }

        private IEnumerable<State> EmptyStates
        { 
            get 
            {
                if (this.emptyStates == null)
                    this.emptyStates = new State[0];

                return this.emptyStates;
            }

        }

        #endregion //Properties

        #region Constructors

        private State() { }

        private State(CharacterSet characterSet) : this()
        {
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");

            this.characterSet = characterSet;
        }

        #endregion //Constructors

        #region Methods

        public IEnumerable<State> TransitionOn(char character)
        {
            if (this.characterSet == null ||
                !this.characterSet.Contains(character))
                return this.EmptyStates;

            return this.NextStates;
        }

        public void AddNextStates(IEnumerable<State> nextStates)
        { 
            if (nextStates == null)
                throw new ArgumentNullException("nextStates");

            foreach (var nextState in nextStates)
                this.nextStates.Add(nextState);
        }

        #endregion //Methods

        #region Static Members

        public static State CreateAcceptor()
        {
            return new State() { IsAcceptor = true };
        }

        public static State CreateAcceptor(CharacterSet characterSet, params State[] nextStates)
        {
            return Create(true, characterSet, nextStates);
        }

        public static State Create(CharacterSet characterSet, params State[] nextStates)
        {
            return Create(false, characterSet, nextStates);
        }

        private static State Create(bool isAcceptor, CharacterSet characterSet, params State[] nextStates)
        {
            var newState = new State(characterSet) { IsAcceptor = isAcceptor };

            foreach (var state in nextStates)
                newState.NextStates.Add(state);

            return newState;
        }

        #endregion //Static Members
    }
}
