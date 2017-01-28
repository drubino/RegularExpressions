using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexing;

namespace Lexing
{
    internal class CharacterSetBuilder : RegexSyntaxTreeVisitor
    {
        #region Fields

        private CharacterSet _characterSet;

        #endregion //Fields

        #region Constructors

        public CharacterSetBuilder()
        {
            _characterSet = new CharacterSet();
        }

        public CharacterSetBuilder(CharacterSet characterSet)
        {
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");

            _characterSet = characterSet;
        }

        #endregion //Constructors

        #region Base Class Overrides

        public override void VisitCharacterSetNode(RegexCharacterSetNode node)
        {
            if (!node.IsInclusive)
                _characterSet.MakeExclusive();

            VisitChildren(node);
        }

        public override void VisitCharacterNode(RegexCharacterNode node)
        {
            _characterSet.AddCharacter(node.Character);
        }

        public override void VisitCharacterRangeNode(RegexCharacterRangeNode node)
        {
            _characterSet.AddRange(node.FirstCharacter, node.LastCharacter);
        }

        public override void VisitSpecialCharacterNode(RegexSpecialCharacterNode node)
        {
            _characterSet.AddSet(node.ToCharacterSet());
        }

        public override void VisitCharacterCategoryNode(RegexCharacterCategoryNode node)
        {
            _characterSet.AddSet(node.ToCharacterSet());
        }

        #endregion //Base Class Overrides

        #region Methods

        public CharacterSet ToCharacterSet()
        {
            return _characterSet;
        }

        #endregion //Methods
    }
}
