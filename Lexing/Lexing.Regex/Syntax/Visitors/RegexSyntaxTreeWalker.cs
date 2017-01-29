using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexing.Regex.Syntax.Visitors
{
    internal class RegexSyntaxTreeWalker : RegexSyntaxTreeVisitor
    {
        protected override void DefaultVisit(RegexNode node)
        {
            VisitChildren(node);
        }
    }
}
