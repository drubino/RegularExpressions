using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexing
{
    internal class Lexer
    {
        #region Fields

        private FiniteAutomaton _automaton;

        #endregion //Fields

        #region Constructors

        public Lexer(FiniteAutomaton automaton)
        {
            if (automaton == null)
                throw new ArgumentNullException("automaton");

            _automaton = automaton;
        }

        #endregion //Constructors

        #region Methods

        #region Tokenize

        public IEnumerable<Token> Tokenize(string input)
        {
            return Tokenize(input.AsScannable());
        }

        public IEnumerable<Token> Tokenize(IScannable<char> input)
        {
            var tokenizer = GetTokenizer(input);
            while (tokenizer.MoveNext())
                yield return tokenizer.Current;
        }

        #endregion //Tokenize

        #region GetTokenizer

        public Tokenizer GetTokenizer(string input)
        {
            return GetTokenizer(input.AsScannable());
        }

        public Tokenizer GetTokenizer(IScannable<char> input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            return new Tokenizer(_automaton.Clone(), input);
        }

        #endregion //GetTokenizer

        #endregion //Methods
    }
}
