using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexing.RegularExpressions
{
    /// <summary>
    /// A set of characters, configurable by adding single characters and ranges of characters.
    /// The set can be inverted by taking its complement.
    /// </summary>
    internal class CharacterSet
    {
        #region Fields

        private bool takeComplement = false;
        private HashSet<char> characters;
        private List<Range> ranges;

        #endregion //Fields

        #region Methods

        public bool Contains(char character)
        {
            var containsCharacter =
                ContainedInRanges(character) ||
                ContainedInCharacters(character);

            if (this.takeComplement)
                containsCharacter = !containsCharacter;

            return containsCharacter;
        }

        public CharacterSet TakeComplement()
        {
            this.takeComplement = !this.takeComplement;
            return this;
        }

        public CharacterSet AddCharacter(char character)
        {
            InitializeCharactersSet();
            this.characters.Add(character);

            return this;
        }

        public CharacterSet AddCharacters(params char[] characters)
        {
            return AddCharacters((IEnumerable<char>)characters);
        }

        public CharacterSet AddCharacters(IEnumerable<char> characters)
        {
            if (characters == null)
                throw new ArgumentNullException("characters");

            InitializeCharactersSet();
            foreach (var character in characters)
                this.characters.Add(character);

            return this;
        }

        public CharacterSet AddRange(char firstCharacter, char lastCharacter)
        {
            InitializeRangesList();
            var first = CharToInt(firstCharacter);
            var last = CharToInt(lastCharacter);
            if (first > last)
                throw new ArgumentException("The firstCharacter must precede or be equivalent to the lastCharacter, as integers.");

            this.ranges.Add(new Range(first, last));

            return this;
        }

        #endregion //Methods

        #region Utilities

        private bool ContainedInCharacters(char character)
        {
            if (this.characters == null)
                return false;

            return this.characters.Contains(character);
        }

        private bool ContainedInRanges(char character)
        {
            if (this.ranges == null)
                return false;

            var value = CharToInt(character);
            foreach (var range in this.ranges)
                if (range.Contains(value))
                    return true;

            return false;
        }

        private void InitializeCharactersSet()
        {
            if (this.characters == null)
                this.characters = new HashSet<char>();
        }

        private void InitializeRangesList()
        {
            if (this.ranges == null)
                this.ranges = new List<Range>();
        }

        private static int CharToInt(char character)
        {
            return Convert.ToInt32(character);
        }

        #endregion //Utilities

        #region Static Methods

        public static CharacterSet Create()
        {
            return new CharacterSet();
        }

        #endregion //Static Methods

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
