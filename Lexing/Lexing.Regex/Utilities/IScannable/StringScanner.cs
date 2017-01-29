using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Lexing.Regex
{
    internal class StringScanner : IScanner<char>
    {
        #region Fields

        private readonly string _input;
        private int _currentIndex = -1;

        //Note: make this tokenizer specific, where it only needs to store the last bookmark.
        private readonly Dictionary<Bookmark, int> _bookmarks = new Dictionary<Bookmark,int>();

        #endregion //Fields

        #region Properties

        private bool HasCurrent
        {
            get 
            { 
                return 
                    _currentIndex < _input.Length && 
                    _currentIndex >= 0; 
            }
        }

        #endregion //Properties

        #region Constructors

        public StringScanner(string input)
        {
            _input = input;
        }

        #endregion //Constructors

        #region IScanner Members

        public bool MoveTo(Bookmark bookmark)
        {
            _currentIndex = _bookmarks[bookmark];
            return this.HasCurrent;
        }

        public Bookmark BookmarkCurrent()
        {
            var bookmark = new Bookmark();
            _bookmarks.Add(bookmark, _currentIndex);

            return bookmark;
        }

        public void ClearBookmarks()
        {
            var bookmarks = _bookmarks;
            if (bookmarks != null)
                bookmarks.Clear();
        }

        #endregion //IScanner Members

        #region IEnumerable Members

        public char Current
        {
            get { return _input[_currentIndex]; }
        }

        object IEnumerator.Current
        {
            get { return _input[_currentIndex]; }
        }

        public bool MoveNext()
        {
            _currentIndex++;
            return this.HasCurrent;
        }

        public void Reset()
        {
            _currentIndex = -1;
            ClearBookmarks();
        }

        public void Dispose() { }

        #endregion //IEnumerable Members
    }
}
