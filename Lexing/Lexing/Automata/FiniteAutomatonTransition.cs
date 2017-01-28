using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexing;

namespace Lexing
{
    internal struct FiniteAutomatonTransition
    {
        #region Fields

        private readonly char? _input;
        private readonly CharacterSet _inputSet;
        private readonly FiniteAutomatonState _state;

        #endregion //Fields

        #region Properties

        public char Input
        {
            get { return _input.Value; }
        }

        public CharacterSet InputSet
        {
            get { return _inputSet; }
        }

        public FiniteAutomatonState State
        {
            get { return _state; }
        }

        public bool IsCharacterTransition
        {
            get { return _input.HasValue; }
        }

        public bool IsSetTransition
        {
            get { return _inputSet != null; }
        }

        #endregion //Properties

        #region Constructors

        public FiniteAutomatonTransition(char input, FiniteAutomatonState state)
        {
            _input = input;
            _inputSet = null;
            _state = state;
        }

        public FiniteAutomatonTransition(CharacterSet inputSet, FiniteAutomatonState state)
        {
            _input = null;
            _inputSet = inputSet;
            _state = state;
        }

        #endregion //Constructors
    }
}
