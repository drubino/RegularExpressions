using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Lexing.Regex
{
    internal abstract class RegexLeafNode : RegexNode
	{
		public override int Count
		{
			get { return 0; }
		}

		public override RegexNode this[int index]
		{
			get
			{
				Utilities.DebugFail("Index out of range.");
				return null;
			}
		}

        public virtual bool IsTerminalNode
        {
            get { return false; }
        }

        public abstract CharacterSet ToCharacterSet();
	}
}