using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexing;
using System.Diagnostics;

namespace Lexing
{
    /// <summary>
    /// Compiles a RegexSyntaxTree into a FiniteAutomaton.
    /// The tree must be terminated with the EndOfRegex special character.
    /// </summary>
    internal class RegexSyntaxTreeCompiler
    {
        #region Fields

        private readonly IEnumerable<RegexSyntaxTree> _syntaxTrees;
        private Dictionary<FiniteAutomatonStateProxy, FiniteAutomatonState> _stateProxies;
        private Queue<FiniteAutomatonStateProxy> _unmarkedStateProxies;
        private ITokenSelector _tokenSelector;

        #endregion //Fields

        #region Constructors

        public RegexSyntaxTreeCompiler(params RegexSyntaxTree[] syntaxTrees)
            : this((IEnumerable<RegexSyntaxTree>)syntaxTrees, new DefaultTokenSelector()) { }

        public RegexSyntaxTreeCompiler(IEnumerable<RegexSyntaxTree> syntaxTrees, ITokenSelector tokenSelector)
        {
            ValidateSyntaxTrees(syntaxTrees);
            if (tokenSelector == null)
                throw new ArgumentNullException("terminalSymbolSelector");

            _syntaxTrees = syntaxTrees;
            _tokenSelector = tokenSelector;
            AnnotateSyntaxTrees();
        }

        #endregion //Constructors

        #region Methods

        public FiniteAutomaton Compile()
        {
            InitializeCompilation();
            var initialState = CreateInitialState();

            var unmarkedStateProxies = _unmarkedStateProxies;
            while (unmarkedStateProxies.Any())
            {
                var currentStateProxy = unmarkedStateProxies.Dequeue();
                var currentState = GetAutomatonState(currentStateProxy);

                AssignTransitions(currentState, currentStateProxy.Positions);
            }

            return new FiniteAutomaton(initialState);
        }

        #endregion //Methods

        #region Utilities

        #region ValidateSyntaxTrees

        private static void ValidateSyntaxTrees(IEnumerable<RegexSyntaxTree> syntaxTrees)
        {
            if (syntaxTrees == null)
                throw new ArgumentNullException("syntaxTrees");
            if (!syntaxTrees.Any())
                throw new ArgumentException("The syntaxTrees are null or empty");
            if (syntaxTrees.HasDuplicates(s => s.TerminalNode.Token))
                throw new ArgumentException("The syntaxTrees have duplicate Tokens.");
        }

        #endregion //ValidateSyntaxTrees

        #region AnnotateSyntaxTrees

        private void AnnotateSyntaxTrees()
        {
            var positionDispenser = new PositionDispenser();
            foreach (var syntaxTree in _syntaxTrees)
                syntaxTree.Accept(
                    new RegexAnnotator(
                        positionDispenser));
        }

        #endregion //AnnotateSyntaxTrees

        #region InitializeCompilation

        private void InitializeCompilation()
        {
            _stateProxies = new Dictionary<FiniteAutomatonStateProxy, FiniteAutomatonState>();
            _unmarkedStateProxies = new Queue<FiniteAutomatonStateProxy>();
        }

        #endregion //InitializeCompilation

        #region CreateInitialState

        private FiniteAutomatonState CreateInitialState()
        {
            var positions =
                from syntaxTree in _syntaxTrees
                from position in syntaxTree.RootNode.Annotations.FirstPositions
                select position;

            var initialStateProxy = CreateStateProxy(positions);
            return GetAutomatonState(initialStateProxy);
        }

        #endregion //CreateInitialState

        #region CreateStateProxy

        private FiniteAutomatonStateProxy CreateStateProxy(IEnumerable<RegexLeafNode> nodes)
        {
            var stateProxy = new FiniteAutomatonStateProxy(nodes.Distinct());
            if (_stateProxies.ContainsKey(stateProxy))
                return stateProxy;

            var newState = new FiniteAutomatonState() { IsAcceptor = stateProxy.IsAcceptorProxy };
            if (newState.IsAcceptor)
                newState.Token = _tokenSelector.SelectFrom(stateProxy.Tokens);

            _stateProxies.Add(stateProxy, newState);
            _unmarkedStateProxies.Enqueue(stateProxy);

            return stateProxy;
        }

        #endregion //CreateStateProxy

        #region GetAutomatonState

        private FiniteAutomatonState GetAutomatonState(FiniteAutomatonStateProxy stateProxy)
        {
            return _stateProxies[stateProxy];
        }

        #endregion //GetAutomatonState

        #region AssignTransitions

        private void AssignTransitions(FiniteAutomatonState currentState, IEnumerable<RegexLeafNode> followPositions)
        {
            var nodePartition = new RegexNodePartition(followPositions);
            AssignCharacterTransitions(currentState, nodePartition);
            AssignCharacterSetTransitions(currentState, nodePartition);
        }

        #endregion //AssignTransitions

        #region AssignCharacterTransitions

        private void AssignCharacterTransitions(FiniteAutomatonState currentState, RegexNodePartition nodePartition)
        {
            foreach (var group in nodePartition.GetNodesPerCharacter())
            {
                var character = group.Character;
                var nextStateProxy = CreateStateProxy(group.Nodes);
                var nextState = GetAutomatonState(nextStateProxy);

                currentState.AddTransition(character, nextState);
            }
        }

        #endregion //AssignCharacterTransitions

        #region AssignCharacterSetTransitions

        private void AssignCharacterSetTransitions(FiniteAutomatonState currentState, RegexNodePartition nodePartition)
        {
            foreach (var group in nodePartition.GetNodesPerCharacterSet())
            {
                var characterSet = group.CharacterSet;
                var nextStateProxy = CreateStateProxy(group.Nodes);
                var nextState = GetAutomatonState(nextStateProxy);

                currentState.AddTransition(characterSet, nextState);
            }
        }

        #endregion //AssignCharacterSetTransitions

        #endregion //Utilities
    }
}
