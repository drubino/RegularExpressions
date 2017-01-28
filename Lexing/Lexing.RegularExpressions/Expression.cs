using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexing.RegularExpressions
{
    internal class Expression
    {
        #region Fields

        private HashSet<State> initialStates = new HashSet<State>();
        private HashSet<State> states = new HashSet<State>();
        private Automata automata;

        #endregion //Fields

        #region Properties

        public bool IsCompiled
        {
            get { return this.automata != null; }
        }

        #endregion //Properties

        #region Constructors

        private Expression() { }

        #endregion //Constructors

        #region Methods

        #region Compile

        public void Compile()
        {
            if (this.automata == null)
                this.automata = new Automata(this.initialStates);

            this.automata.Reset();
        }

        #endregion //Compile

        #region Run

        public Result Run(IEnumerable<char> characters)
        {
            Compile();

            var builder = new StringBuilder();
            var passedAcceptingState = this.automata.InAcceptingState;

            foreach (var character in characters)
            {
                if (!this.automata.CanTransition)
                    break;

                this.automata.TransitionOn(character);

                var currentlyInAcceptingState = this.automata.InAcceptingState;
                if (!currentlyInAcceptingState && passedAcceptingState)
                    break;

                if (currentlyInAcceptingState)
                    passedAcceptingState = true;

                builder.Append(character);
            }

            if (!passedAcceptingState)
                return new Result();

            return new Result(builder.ToString());
        }

        #endregion //Run

        #region Concat

        public Expression Concat(Expression expression)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");

            var acceptorStates = GetAcceptorStates();
            foreach (var state in acceptorStates)
            {
                state.IsAcceptor = false;
                foreach (var initialState in expression.initialStates)
                    state.NextStates.Add(initialState);
            }

            foreach (var state in expression.initialStates)
                this.states.Add(state);

            if (this.initialStates.Any(s => s.IsAcceptor))
                foreach (var state in expression.initialStates)
                    this.initialStates.Add(state);

            ResetCompilation();
            return this;
        }

        #endregion //Concat

        #region Or

        public Expression Or(Expression expression)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");

            foreach (var state in expression.initialStates)
                this.initialStates.Add(state);

            foreach (var state in expression.states)
                this.states.Add(state);

            ResetCompilation();
            return this;
        }

        #endregion //Or

        #region Optional

        public Expression Optional()
        {
            foreach (var state in this.initialStates)
                state.IsAcceptor = true;

            ResetCompilation();
            return this;
        }

        #endregion //Optional

        #region ZeroOrMore

        public Expression ZeroOrMore()
        {
            foreach (var state in this.initialStates)
                state.IsAcceptor = true;

            foreach (var state in GetAcceptorStates())
                state.AddNextStates(this.initialStates);

            return this;
        }

        #endregion //ZeroOrMore

        #endregion //Methods

        #region Utilities

        #region ResetCompilation

        private void ResetCompilation()
        {
            this.automata = null;
        }

        #endregion //ResetCompilation

        #region GetAcceptorStates

        private IEnumerable<State> GetAcceptorStates()
        {
            return this.states.Where(s => s.IsAcceptor);
        }

        #endregion //GetAcceptorStates

        #endregion //Utilities

        #region Static Members

        public static Expression Create(CharacterSet characterSet)
        {
            var newExpression = new Expression();
            var acceptorState = State.CreateAcceptor();
            var initialState = State.Create(characterSet, State.CreateAcceptor());

            newExpression.initialStates.Add(initialState);
            newExpression.states.Add(initialState);
            newExpression.states.Add(acceptorState);

            return newExpression;
        }

        #endregion //Static Members
    }
}
