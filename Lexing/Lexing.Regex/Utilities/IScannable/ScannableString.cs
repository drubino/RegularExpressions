using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Lexing.Regex
{
    internal class ScannableString : IScannable<char>
    {
        private readonly string _input;

        public ScannableString(string input)
        {
            _input = input;
        }

        public IScanner<char> GetScanner()
        {
            return new StringScanner(_input);
        }

        public IEnumerator<char> GetEnumerator()
        {
            return GetScanner();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return
                ((IEnumerable<char>)this)
                .GetEnumerator();
        }
    }
}
