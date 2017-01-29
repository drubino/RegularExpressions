using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexing.Regex
{
    internal struct Token
    {
        #region Fields

        private readonly string _name;
        private readonly string _content;

        #endregion //Fields

        #region Properties

        public string Name
        {
            get { return _name; }
        }

        public string Content
        {
            get { return _content; }
        }

        public bool IsValidToken
        {
            get { return _name != null; }
        }

        #endregion //Properties

        #region Constructors

        public Token(string name, string content)
        {
            _name = name;
            _content = content;
        }

        #endregion //Constructors

        #region Base Class Overrides

        public override string ToString()
        {
            if (!IsValidToken)
                return "*Error: " + _content;

            return _name + ": " + _content;
        }

        #endregion //Base Class Overrides

        #region Static Members

        public static Token Error(string content)
        {
            return new Token(null, content);
        }

        #endregion //Static Members
    }
}
