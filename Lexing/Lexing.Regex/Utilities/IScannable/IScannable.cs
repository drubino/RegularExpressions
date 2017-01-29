using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexing.Regex
{
    internal interface IScannable<T> : IEnumerable<T>
    {
        IScanner<T> GetScanner();
    }
}
