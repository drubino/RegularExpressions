using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexing
{
    /// <summary>
    /// An implementation of a discrete finite automaton.
    /// </summary>
    internal class FiniteAutomaton
    {
        #region Fields

        private FiniteAutomatonState _initialState;
        private FiniteAutomatonState _currentState;

        #endregion //Fields

        #region Properties

        public bool CanTransition
        {
            get { return _currentState != null; }
        }

        public bool Accepts
        {
            get
            {
                var currentState = _currentState;
                return 
                    currentState != null && 
                    currentState.IsAcceptor;
            }
        }

        public string Token
        {
            get { return _currentState.Token; }
        }

        #endregion //Properties

        #region Constructors

        public FiniteAutomaton(FiniteAutomatonState initialState)
        {
            if (initialState == null)
                throw new ArgumentNullException("initialState");

            _initialState = initialState;
            Reset();
        }

        #endregion //Constructors

        #region Methods

        #region TransitionOn

        public void TransitionOn(char input)
        { 
            var currentState = _currentState;
            if (currentState != null)
                _currentState = currentState.TransitionOn(input);
        }

        #endregion //TransitionOn

        #region RejectInitialState

        public FiniteAutomaton RejectInitialState()
        {
            var initialState = _initialState;
            if (!initialState.IsAcceptor)
                return this;

            var newInitialState = new FiniteAutomatonState();
            foreach (var transition in initialState)
                newInitialState.AddTransition(transition.Input, transition.State);

            _initialState = newInitialState;

            return this;
        }

        #endregion //RejectInitialState

        #region Reset

        public void Reset()
        {
            _currentState = _initialState;
        }

        #endregion //Reset

        #region Clone

        /// <summary>
        /// Performs a clone which does not preserve the current state.
        /// </summary>
        /// <returns>A clone of the current finite automaton.</returns>
        public FiniteAutomaton Clone()
        {
            return new FiniteAutomaton(_initialState);
        }

        #endregion //Clone

        #endregion //Methods
    }
}
