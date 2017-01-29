using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using Lexing.Regex;

namespace Lexing.Regex
{
	internal static class Utilities
	{
		#region DebugFail

		public static void DebugFail(string message)
		{
#if SILVERLIGHT
            Debug.Assert( false, message );
#else
			Debug.Fail(message);
#endif
		}

		#endregion // DebugFail

        #region HasDuplicates

        public static bool HasDuplicates<TItem, TKey>(this IEnumerable<TItem> items, Func<TItem, TKey> selector)
        {
            if (items == null)
                return false;

            var set = new HashSet<TKey>();
            foreach (var item in items)
                if (!set.Add(selector(item)))
                    return true;

            return false;
        }

        #endregion //HasDuplicates

        #region AsScannable

        public static IScannable<char> AsScannable(this string str)
        {
            return new ScannableString(str);
        }

        #endregion //AsScannable
	}
}
