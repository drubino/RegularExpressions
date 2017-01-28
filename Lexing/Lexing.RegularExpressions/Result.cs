using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexing.RegularExpressions
{
    internal struct Result
    {
        private string value;
        public bool HasValue { get { return this.Value != null; } }
        public string Value { get { return value; } }

        public Result(string value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            this.value = value;
        }

        public override string ToString()
        {
            if (!this.HasValue)
                return "No Value";

            return "Value: " + this.Value;
        }
    }
}
