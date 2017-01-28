using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Lexing;

namespace Lexing
{
    internal class RegexSyntaxTree
	{
        #region Fields

        private readonly RegexConcatenationNode _rootNode;

        #endregion //Fields

        #region Properties

        public RegexConcatenationNode RootNode
        {
            get { return _rootNode; }
        }

        public RegexNode ParsedRootNode
        {
            get { return _rootNode.Left; }
        }

        public RegexTerminalNode TerminalNode
        {
            get { return (RegexTerminalNode)_rootNode.Right; }
        }

        #endregion //Properties

        #region Constructors

        public RegexSyntaxTree(RegexConcatenationNode rootNode)
        {
            if (rootNode == null)
                throw new ArgumentNullException("rootNode");
            if (!(rootNode.Right is RegexTerminalNode))
                throw new ArgumentException("The rootNode is not terminated correctly.");

            _rootNode = rootNode;
        }

        #endregion //Constructors

        #region Methods

        public void Accept(RegexSyntaxTreeVisitor visitor)
        {
            this.RootNode.Accept(visitor);
        }

        #endregion //Methods
	}
}