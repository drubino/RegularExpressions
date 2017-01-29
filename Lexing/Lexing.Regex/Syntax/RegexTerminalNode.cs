using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexing.Regex
{
    internal class RegexTerminalNode : RegexLeafNode
    {
        #region Fields

        private readonly string _token;

        #endregion //Fields

        #region Properties

        public string Token
        {
            get { return _token; }
        }

        #endregion //Properties

        #region Constructors

        public RegexTerminalNode(string token)
        {
            if (token == null)
                throw new ArgumentNullException("token");

            _token = token;
        }

        #endregion //Constructors

        #region Base Class Overrides

        #region ToString

        public override string ToString()
        {
            return base.ToString() + ": #" + _token;
        }

        #endregion //ToString

        #region Accept

        public override void Accept(RegexSyntaxTreeVisitor visitor)
        {
            visitor.VisitTerminalNode(this);
        }

        #endregion //Accept

        #region DeepClone

        public sealed override RegexNode DeepClone()
        {
            return new RegexTerminalNode(_token);
        }

        #endregion //DeepClone

        #region ToCharacterSet

        public override CharacterSet ToCharacterSet()
        {
            return new CharacterSet();
        }

        #endregion //ToCharacterSet

        #region IsTerminalNode

        public override bool IsTerminalNode
        {
            get { return true; }
        }

        #endregion //IsTerminalNode

        #endregion //Base Class Overrides
    }
}
