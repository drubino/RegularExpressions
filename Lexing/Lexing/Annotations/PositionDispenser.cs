using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexing
{
    internal class PositionDispenser
    {
        uint _nextPosition = 1;

        public uint GetNextPosition()
        {
            return _nextPosition++;
        }
    }
}
