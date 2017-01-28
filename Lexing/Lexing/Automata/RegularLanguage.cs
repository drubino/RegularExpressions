using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexing;

namespace Lexing
{
    /// <summary>
    /// A set of words that can be defined by a regular expression.
    /// </summary>
    internal class RegularLanguage
    {
        private readonly FiniteAutomaton _automaton;

        public RegularLanguage(FiniteAutomaton automaton)
        {
            if (automaton == null)
                throw new ArgumentNullException("automaton");

            _automaton = automaton;
        }

        public bool Contains(string word)
        {
            if (word == null)
                throw new ArgumentNullException("word");

            _automaton.Reset();
            foreach (var character in word)
            {
                if (!_automaton.CanTransition)
                    return false;

                _automaton.TransitionOn(character);
            }

            return _automaton.Accepts;
        }
    }
}
