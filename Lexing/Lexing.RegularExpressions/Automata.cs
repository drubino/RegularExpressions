using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace Lexing.RegularExpressions
{
    internal class Automata
    {
        #region Fields

        private HashSet<State> initialStates = new HashSet<State>();
        private HashSet<State> currentStates = new HashSet<State>();
        private HashSet<State> nextStates = new HashSet<State>();

        #endregion //Fields

        #region Properties

        public bool InAcceptingState
        {
            get { return this.currentStates.Any(s => s.IsAcceptor); }
        }

        public bool CanTransition
        {
            get { return this.currentStates.Any(); }
        }

        #endregion //Properties

        #region Constructors

        public Automata(params State[] initialStates) : this((IEnumerable<State>)initialStates) { }

        public Automata(IEnumerable<State> initialStates)
        {
            if (initialStates == null)
                throw new ArgumentNullException("initialStates");

            foreach (var state in initialStates)
                this.initialStates.Add(state);

            Reset();
        }

        #endregion //Constructors

        #region Methods

        public void TransitionOn(char character)
        {
            var currentStates = this.currentStates;
            var nextStates = this.nextStates;

            foreach (var state in currentStates)
            {
                var nextStatesFromState = state.TransitionOn(character);
                foreach (var nextState in nextStatesFromState)
                    nextStates.Add(nextState);
            }

            currentStates.Clear();
            this.currentStates = nextStates;
            this.nextStates = currentStates;
        }

        public void Reset()
        {
            this.currentStates.Clear();
            this.nextStates.Clear();
            foreach (var state in this.initialStates)
                this.currentStates.Add(state);
        }

        #endregion //Methods
    }
}
