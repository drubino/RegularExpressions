using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexing
{
    /// <summary>
    /// A set of characters, configurable by adding single characters and ranges of characters.
    /// The set can be inverted by taking its complement.
    /// </summary>
    internal class CharacterSet
    {
        #region Fields

        private bool _isExclusive = false;
        private HashSet<char> _characters;
        private List<Range> _ranges;
        private List<CharacterSet> _sets;

        #endregion //Fields

        #region Methods

        #region Contains

        public bool Contains(char character)
        {
            var containsCharacter =
                ContainedInRanges(character) ||
                ContainedInCharacters(character) ||
                ContainedInSets(character);

            if (_isExclusive)
                containsCharacter = !containsCharacter;

            return containsCharacter;
        }

        #endregion //Contains

        #region MakeExclusive

        public CharacterSet MakeExclusive()
        {
            _isExclusive = true;
            return this;
        }

        #endregion //MakeExclusive

        #region MakeInclusive

        public CharacterSet MakeInclusive()
        {
            _isExclusive = false;
            return this;
        }

        #endregion //MakeInclusive

        #region AddCharacter

        public CharacterSet AddCharacter(char character)
        {
            InitializeCharacters();
            _characters.Add(character);

            return this;
        }

        #endregion //AddCharacter

        #region AddCharacters

        public CharacterSet AddCharacters(params char[] characters)
        {
            return AddCharacters((IEnumerable<char>)characters);
        }

        public CharacterSet AddCharacters(IEnumerable<char> characters)
        {
            if (characters == null)
                throw new ArgumentNullException("characters");

            InitializeCharacters();
            foreach (var character in characters)
                _characters.Add(character);

            return this;
        }

        #endregion //AddCharacters

        #region AddRange

        public CharacterSet AddRange(char firstCharacter, char lastCharacter)
        {
            InitializeRanges();
            var first = CharToInt(firstCharacter);
            var last = CharToInt(lastCharacter);
            if (first > last)
                throw new ArgumentException("The firstCharacter must precede or be equivalent to the lastCharacter, as integers.");

            _ranges.Add(new Range(first, last));

            return this;
        }

        #endregion //AddRange

        #region AddSet

        public CharacterSet AddSet(CharacterSet set)
        {
            if (set == null)
                throw new ArgumentNullException("set");

            InitializeSets();
            _sets.Add(set);

            return this;
        }

        #endregion //AddSet

        #endregion //Methods

        #region Utilities

        #region ContainedInCharacters

        private bool ContainedInCharacters(char character)
        {
            if (_characters == null)
                return false;

            return _characters.Contains(character);
        }

        #endregion //ContainedInCharacters

        #region ContainedInRanges

        private bool ContainedInRanges(char character)
        {
            if (_ranges == null)
                return false;

            var value = CharToInt(character);
            foreach (var range in _ranges)
                if (range.Contains(value))
                    return true;

            return false;
        }

        #endregion //ContainedInRanges

        #region ContainedInSets

        private bool ContainedInSets(char character)
        {
            if (_sets == null)
                return false;

            foreach (var set in _sets)
                if (set.Contains(character))
                    return true;

            return false;
        }

        #endregion //ContainedInSets

        #region InitializeCharacters

        private void InitializeCharacters()
        {
            if (_characters == null)
                _characters = new HashSet<char>();
        }

        #endregion //InitializeCharacters

        #region InitializeRangesList

        private void InitializeRanges()
        {
            if (_ranges == null)
                _ranges = new List<Range>();
        }

        #endregion //InitializeRangesList

        #region InitializeSets

        private void InitializeSets()
        {
            if (_sets == null)
                _sets = new List<CharacterSet>();
        }

        #endregion //InitializeSets

        #region CharToInt

        private static int CharToInt(char character)
        {
            return (int)character;
        }

        #endregion //CharToInt

        #endregion //Utilities

        #region Nested Classes

        private struct Range
        {
            private int first;
            private int last;

            public Range(int first, int last)
            {
                this.first = first;
                this.last = last;
            }

            public bool Contains(int value)
            {
                return
                    value >= this.first &&
                    value <= this.last;
            }
        }

        #endregion //Nested Classes
    }
}
