using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexing.Regex;

namespace Lexing.Regex
{
    internal class RegexNodePartition
    {
        #region Fields

        private Dictionary<char, IEnumerable<RegexLeafNode>> _characterPositions;
        private Dictionary<CharacterSet, IEnumerable<RegexLeafNode>> _characterSetPositions;

        #endregion //Fields

        #region Constructor

        public RegexNodePartition(IEnumerable<RegexLeafNode> node)
        {
            if (node == null)
                throw new ArgumentNullException("nodes");

            SortCharacterPositions(node);
            SortCharacterSetPositions(node);
        }

        #endregion //Constructor

        #region Methods

        public IEnumerable<CharacterEquivalenceGroup> GetNodesPerCharacter()
        { 
            var characterSets = _characterSetPositions;
            foreach (var pair in _characterPositions)
            {
                var character = pair.Key;
                var matchingNodes = 
                    pair.Value.Concat(
                    GetCharacterSetNodesWhichMatch(character));

                yield return new CharacterEquivalenceGroup(character, matchingNodes);
            }
        }

        public IEnumerable<CharacterSetEquivalenceGroup> GetNodesPerCharacterSet()
        {
            foreach (var pair in _characterSetPositions)
            {
                var characterSet = pair.Key;
                var matchingNodes = pair.Value;

                yield return new CharacterSetEquivalenceGroup(characterSet, matchingNodes);
            }
        }

        #endregion //Methods

        #region Utilities

        private void SortCharacterPositions(IEnumerable<RegexLeafNode> nodes)
        {
            _characterPositions = 
                (from characterPosition in nodes.OfType<RegexCharacterNode>()
                 let character = characterPosition.Character
                 from followPosition in characterPosition.Annotations.FollowPositions
                 group followPosition by character)
                .ToDictionary(g => g.Key, g => g.Cast<RegexLeafNode>());
        }

        private void SortCharacterSetPositions(IEnumerable<RegexLeafNode> nodes)
        {
            _characterSetPositions =
                (from characterSetPosition in nodes
                 where !(characterSetPosition is RegexCharacterNode)
                 let characterSet = characterSetPosition.ToCharacterSet()
                 from followPosition in characterSetPosition.Annotations.FollowPositions
                 group followPosition by characterSet)
                .ToDictionary(g => g.Key, g => (IEnumerable<RegexLeafNode>)g);
                
        }

        private IEnumerable<RegexLeafNode> GetCharacterSetNodesWhichMatch(char character)
        {
            return
                from pair in _characterSetPositions
                let set = pair.Key
                where set.Contains(character)
                from position in pair.Value
                select position;
        }

        #endregion //Utilities
    }

    #region CharacterEquivalenceGroup

    internal struct CharacterEquivalenceGroup
    {
        private readonly char character;
        private readonly IEnumerable<RegexLeafNode> nodes;

        public char Character
        {
            get { return this.character; }
        }

        public IEnumerable<RegexLeafNode> Nodes
        {
            get { return this.nodes; }
        }

        public CharacterEquivalenceGroup(char character, IEnumerable<RegexLeafNode> nodes)
        {
            this.character = character;
            this.nodes = nodes;
        }
    }

    #endregion //CharacterEquivalenceNodeGroup

    #region CharacterEquivalenceGroup

    internal struct CharacterSetEquivalenceGroup
    {
        private readonly CharacterSet characterSet;
        private readonly IEnumerable<RegexLeafNode> nodes;

        public CharacterSet CharacterSet
        {
            get { return this.characterSet; }
        }

        public IEnumerable<RegexLeafNode> Nodes
        {
            get { return this.nodes; }
        }

        public CharacterSetEquivalenceGroup(CharacterSet characterSet, IEnumerable<RegexLeafNode> nodes)
        {
            this.characterSet = characterSet;
            this.nodes = nodes;
        }
    }

    #endregion //CharacterEquivalenceNodeGroup
}
