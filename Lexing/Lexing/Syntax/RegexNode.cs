using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Lexing;
using System.Collections;

namespace Lexing
{
	internal abstract class RegexNode : IEnumerable<RegexNode>
	{
        #region Properties

        public abstract int Count { get; }

        public abstract RegexNode this[int index] { get; }

        public RegexNode this[params int[] indexes] 
        {
            get
            {
                var currentNode = this;
                foreach (var index in indexes)
                    currentNode = currentNode[index];

                return currentNode;
            }
        }

        public RegexNodeAnnotations Annotations { get; private set; }

        #endregion //Properties

        #region Constructors

        public RegexNode()
        {
            this.Annotations = new RegexNodeAnnotations(this);
        }

        #endregion //Constructors

        #region IEnumerable Members

        public IEnumerator<RegexNode> GetEnumerator()
        {
            for (int i = 0, count = this.Count; i < count; i++)
                yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return 
                ((IEnumerable<RegexNode>)this)
                .GetEnumerator();
        }

        #endregion //IEnumerable Members

        #region Base Class Overrides

        public override string ToString()
        {
            return this.GetType().Name;
        }

        #endregion //Base Class Overrides

        #region Methods

        public abstract void Accept(RegexSyntaxTreeVisitor visitor);

		public abstract RegexNode DeepClone();

        #endregion //Methods
    }
}