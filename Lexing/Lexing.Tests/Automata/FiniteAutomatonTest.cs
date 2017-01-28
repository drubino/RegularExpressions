using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lexing.Tests
{
    [TestClass]
    public class FiniteAutomatonTest : LexingTest
    {
        #region ConstructorTest

        [TestMethod]
        public void ConstructorTest()
        {
            var automaton = new FiniteAutomaton(
                initialState: new FiniteAutomatonState().MakeAcceptor());

            Assert.IsTrue(automaton.Accepts);
            AssertThrows<ArgumentNullException>(() => new FiniteAutomaton(null));
        }

        #endregion //ConstructorTest

        #region TransitionOnTest

        [TestMethod]
        public void TransitionOnTest()
        {
            var initialState = new FiniteAutomatonState();
            var acceptorState = 
                new FiniteAutomatonState()
                .AddTransition('b', initialState)
                .MakeAcceptor();

            initialState
                .AddTransition('a', acceptorState)
                .AddTransition('b', initialState);

            var automaton = new FiniteAutomaton(initialState);

            AssertState(
                automaton: automaton, 
                inputs: "",
                accepts: false);

            AssertState(
                automaton: automaton,
                inputs: "a",
                accepts: true);

            AssertState(
                automaton: automaton,
                inputs: "b",
                accepts: false);

            AssertState(
                automaton: automaton,
                inputs: "c",
                accepts: false);

            AssertState(
                automaton: automaton,
                inputs: "aa",
                accepts: false);

            AssertState(
                automaton: automaton,
                inputs: "ab",
                accepts: false);

            AssertState(
                automaton: automaton,
                inputs: "aba",
                accepts: true);

            AssertState(
                automaton: automaton,
                inputs: "abababa",
                accepts: true);

            AssertState(
                automaton: automaton,
                inputs: "bbbbbbabababa",
                accepts: true);
        }

        #endregion //TransitionOnTest

        #region RejectInitialStateTest

        [TestMethod]
        public void RejectInitialStateTest()
        {
            var initialState = new FiniteAutomatonState();
            initialState
                .MakeAcceptor()
                .AddTransition('a', initialState);

            var automaton = new FiniteAutomaton(initialState);

            //Accepts initial state
            AssertState(
                automaton: automaton,
                inputs: "",
                accepts: true);

            AssertState(
                automaton: automaton,
                inputs: "a",
                accepts: true);

            AssertState(
                automaton: automaton,
                inputs: "aaaaa",
                accepts: true);

            automaton.RejectInitialState();

            //Rejects initial state
            AssertState(
                automaton: automaton,
                inputs: "",
                accepts: false);

            AssertState(
                automaton: automaton,
                inputs: "a",
                accepts: true);

            AssertState(
                automaton: automaton,
                inputs: "aaaaa",
                accepts: true);
        }

        #endregion //RejectInitialStateTest

        #region Utilities

        private void AssertState(FiniteAutomaton automaton, IEnumerable<char> inputs, bool accepts)
        {
            automaton.Reset();
            foreach (var input in inputs)
                automaton.TransitionOn(input);

            Assert.AreEqual(accepts, automaton.Accepts);
            automaton.Reset();
        }

        #endregion //Utilities
    }
}
