using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace Lexing.Regex
{
    internal class Tokenizer : IEnumerator<Token>
    {
        #region Fields

        private Token _current;
        private FiniteAutomaton _automaton;
        private IScanner<char> _scanner;
        private bool _scannerHasCurrent;

        #endregion //Fields

        #region Constructors

        public Tokenizer(FiniteAutomaton automaton, IScannable<char> input)
        {
            _automaton = automaton;
            _scanner = input.GetScanner();
            Reset();
        }

        #endregion //Constructors

        #region IEnumerator Members

        #region Current

        public Token Current
        {
            get { return _current; }
        }

        object IEnumerator.Current
        {
            get { return _current; }
        }

        #endregion //Current

        #region MoveNext

        public bool MoveNext()
        {
            if (!_scannerHasCurrent)
                return false;

            var content = new StringBuilder();
            if (!TrySetCurrentToken(content))
                SetErrorToken(content);

            _automaton.Reset();
            return true;
        }

        #endregion //MoveNext

        #region Reset

        public void Reset()
        {
            _automaton.Reset();
            _scanner.Reset();
            _scannerHasCurrent = _scanner.MoveNext();
            _current = Token.Error(string.Empty);
        }

        #endregion //Reset

        #region Dispose

        public void Dispose() { }

        #endregion //Dispose

        #endregion //IEnumerator Members

        #region Utilities

        #region TrySetCurrentToken

        private bool TrySetCurrentToken(StringBuilder content)
        {
            var automaton = _automaton;
            var scanner = _scanner;
            char currentInput;

            string acceptedToken = string.Empty;
            Bookmark acceptedBookmark = null;
            StringBuilder candidateContent = new StringBuilder();


            //While we can transition
            while (automaton.CanTransition && _scannerHasCurrent)
            {
                //Transition the automaton
                currentInput = scanner.Current;
                automaton.TransitionOn(currentInput);

                //Add a content candidate
                candidateContent.Append(currentInput);

                //And get the next input character.
                _scannerHasCurrent = scanner.MoveNext();

                //If we are in an accept state
                if (automaton.Accepts)
                {
                    //Note the token, add the content and bookmark the scanner
                    acceptedToken = automaton.Token;
                    content.Append(candidateContent);
                    candidateContent = new StringBuilder();
                    acceptedBookmark = scanner.BookmarkCurrent();
                }
            }

            //Return if we've never bookmarked an accept state
            if (acceptedBookmark == null)
            {
                content.Append(candidateContent);
                return false;
            }

            //Otherwise move back the scanner
            _scannerHasCurrent = scanner.MoveTo(acceptedBookmark);
            scanner.ClearBookmarks();

            //And set the current token
            _current = new Token(acceptedToken, content.ToString());
            
            return true;
        }

        #endregion //TrySetCurrentToken

        #region SetErrorToken

        private void SetErrorToken(StringBuilder content)
        {
            var automaton = _automaton;
            var scanner = _scanner;
            char currentInput;
            bool automatonCanTransition =
                automaton.CanTransition;

            //While we can't transition
            while (!automatonCanTransition && _scannerHasCurrent)
            {
                currentInput = scanner.Current;

                //Reset the automaton and transition
                automaton.Reset();
                automaton.TransitionOn(currentInput);
                automatonCanTransition = automaton.CanTransition;

                //If the automata can't transition its an error
                if (!automatonCanTransition)
                {
                    //Add the current input to the content and move the scanner.
                    content.Append(currentInput);
                    _scannerHasCurrent = scanner.MoveNext();
                }
            }

            //If we ran out of characters
            if (_scannerHasCurrent)
            {
                _current = Token.Error(content.ToString());
                return;
            }

            //Otherwise we transitioned.
            //Set the error token and be done
            _current = Token.Error(content.ToString());
        }

        #endregion //SetErrorToken

        #endregion //Utilities
    }
}
