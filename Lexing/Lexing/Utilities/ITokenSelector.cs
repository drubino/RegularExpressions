using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexing
{
    /// <summary>
    /// Selects a single token from a collection of tokens.
    /// </summary>
    internal interface ITokenSelector
    {
        string SelectFrom(IEnumerable<string> tokens);
    }

    /// <summary>
    /// Selects the first token in alphabetical order.
    /// </summary>
    internal class DefaultTokenSelector : ITokenSelector
    {
        public virtual string SelectFrom(IEnumerable<string> tokens)
        {
            return tokens.OrderBy(s => s).FirstOrDefault();
        }
    }
}
