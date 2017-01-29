using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexing.Regex;

namespace Lexing.Regex
{
    internal class RegexAnnotator : RegexSyntaxTreeVisitorCombinator
    {
        public RegexAnnotator(PositionDispenser positionDispenser) : base(
            TreeWalkingOptions.BottomUp,
            new PositionAnnotator(positionDispenser),
            new NullableAnnotator(),
            new FirstPositionAnnotator(),
            new LastPositionAnnotator(),
            new FollowPositionAnnotator()) { }
    }
}
