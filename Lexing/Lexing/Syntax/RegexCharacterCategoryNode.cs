using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Lexing;

namespace Lexing
{
    internal sealed class RegexCharacterCategoryNode : RegexLeafNode
	{
        #region Fields

        private readonly string _categoryName;
        private readonly bool _isInclusive;

        #endregion //Fields

        #region Properties

        public string CategoryName
        {
            get { return _categoryName; }
        }

        public bool IsInclusive
        {
            get { return _isInclusive; }
        }

        #endregion //Properties

        #region Constructors

        public RegexCharacterCategoryNode(string categoryName, bool isInclusive)
        {
            _categoryName = categoryName;
            _isInclusive = isInclusive;
        }

        #endregion //Constructors

        #region Base Class Overrides

        #region ToString

        public override string ToString()
        {
            return base.ToString() + ": \\" + (_isInclusive ? 'p' : 'P') + "{" + _categoryName + "}";
        }

        #endregion //ToString

        #region Accept

        public sealed override void Accept(RegexSyntaxTreeVisitor visitor)
        {
            visitor.VisitCharacterCategoryNode(this);
        }

        #endregion //Accept

        #region DeepClone

        public sealed override RegexNode DeepClone()
        {
            return new RegexCharacterCategoryNode(_categoryName, _isInclusive);
        }

        #endregion //DeepClone

        #region ToCharacterSet

        public override CharacterSet ToCharacterSet()
        {
            var set = new CharacterSet();
            set.AddCategory(this.CategoryName);
            if (!this.IsInclusive)
                set.MakeExclusive();

            return set;
        }

        #endregion //ToCharacterSet

        #endregion //Base Class Overrides
	}
}