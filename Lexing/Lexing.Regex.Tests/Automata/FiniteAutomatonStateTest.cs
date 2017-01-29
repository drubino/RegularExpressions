using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lexing.Regex.Tests
{
    [TestClass]
    public class FiniteAutomatonStateTest : LexingTest
    {
        #region AddTransitionTest

        [TestMethod]
        public void AddTransitionTest()
        {
            var firstState = new FiniteAutomatonState();
            var secondState = new FiniteAutomatonState();

            firstState.AddTransition('a', secondState);
            Assert.AreEqual(secondState, firstState.TransitionOn('a'));

            AssertThrows<ArgumentNullException>(() => new FiniteAutomatonState().AddTransition('a', null));
        }

        #endregion //AddTransitionTest

        #region TransitionOnTest

        [TestMethod]
        public void TransitionOnTest()
        {
            var firstState = new FiniteAutomatonState();
            var secondState = new FiniteAutomatonState();

            firstState
                .AddTransition('a', secondState)
                .AddTransition('b', firstState);

            Assert.AreEqual(secondState, firstState.TransitionOn('a'));
            Assert.AreEqual(firstState, firstState.TransitionOn('b'));
        }

        #endregion //TransitionOnTest

        #region SetTransitionOnTest

        [TestMethod]
        public void SetTransitionOnTest()
        {
            var firstState = new FiniteAutomatonState();
            var secondState = new FiniteAutomatonState();
            var set = new CharacterSet()
                .AddCharacter('a')
                .AddRange('a', 'z');

            firstState
                .AddTransition('a', secondState)
                .AddTransition(set, firstState);

            Assert.AreEqual(secondState, firstState.TransitionOn('a'));
            Assert.AreEqual(firstState, firstState.TransitionOn('b'));
            Assert.AreEqual(firstState, firstState.TransitionOn('c'));
            Assert.AreEqual(firstState, firstState.TransitionOn('z'));
        }

        #endregion //SetTransitionOnTest

        #region GetEnumeratorTest

        [TestMethod]
        public void GetEnumeratorTest()
        {
            var state = new FiniteAutomatonState();
            state
                .AddTransition('c', state)
                .AddTransition('b', state)
                .AddTransition('a', state);

            Assert.AreEqual(3, state.Count());

            var inputs = state.Select(s => s.Input).ToList();
            Assert.IsTrue(inputs.Contains('a'));
            Assert.IsTrue(inputs.Contains('b'));
            Assert.IsTrue(inputs.Contains('c'));
            Assert.IsFalse (inputs.Contains('d'));

            var distinctStates = state.Select(s => s.State).Distinct().ToList();
            Assert.AreEqual(1, distinctStates.Count());
            Assert.IsTrue(distinctStates.Contains(state));

            state = new FiniteAutomatonState();
            state
                .AddTransition('c', state)
                .AddTransition('b', state)
                .AddTransition('a', state)
                .AddTransition(
                    new CharacterSet().AddRange('d', 'g'), 
                    state);

            inputs = state.Where(s => s.IsCharacterTransition).Select(s => s.Input).ToList();
            Assert.IsTrue(inputs.Contains('a'));
            Assert.IsTrue(inputs.Contains('b'));
            Assert.IsTrue(inputs.Contains('c'));
            Assert.IsFalse(inputs.Contains('d'));

            var setInputs = state.Where(s => s.IsSetTransition).Select(s => s.InputSet).ToList();
            Assert.IsTrue(setInputs.Count == 1);

            distinctStates = state.Select(s => s.State).Distinct().ToList();
            Assert.AreEqual(1, distinctStates.Count());
            Assert.IsTrue(distinctStates.Contains(state));
        }

        #endregion //GetEnumeratorTest
    }
}
