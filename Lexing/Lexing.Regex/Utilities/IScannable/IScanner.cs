using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexing.Regex
{
    internal interface IScanner<T> : IEnumerator<T>
    {
        Bookmark BookmarkCurrent();

        bool MoveTo(Bookmark bookmark);

        void ClearBookmarks();
    }

    internal class Bookmark { }
}
