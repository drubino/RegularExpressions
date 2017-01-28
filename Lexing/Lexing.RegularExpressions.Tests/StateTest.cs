using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lexing.RegularExpressions.Tests
{
    [TestClass]
    public class StateTest : TestBase
    {
        #region CreateAcceptorTest

        [TestMethod]
        public void CreateAcceptorTest()
        {
            var acceptor = State.CreateAcceptor();
            Assert.IsTrue(acceptor.IsAcceptor);
            Assert.IsTrue(acceptor.NextStates.Count == 0);

            acceptor = State.CreateAcceptor(new CharacterSet(), State.CreateAcceptor());
            Assert.IsTrue(acceptor.IsAcceptor);
            Assert.IsTrue(acceptor.NextStates.Count > 0);
        }

        #endregion //CreateAcceptorTest

        #region CreateTest

        [TestMethod]
        public void CreateTest()
        {
            var state = State.Create(new CharacterSet(), State.CreateAcceptor());
            Assert.IsFalse(state.IsAcceptor);
            Assert.IsTrue(state.NextStates.Count > 0);
        }

        #endregion //CreateTest

        #region TransitionOnTest

        [TestMethod]
        public void TransitionOnTest()
        {
            var state = State.CreateAcceptor();
            Assert.IsTrue(state.TransitionOn('a').Count() == 0);

            state = State.Create(
                CharacterSet.Create().AddRange('a', 'c'),
                State.CreateAcceptor());

            Assert.IsTrue(state.TransitionOn('a').Count() > 0);
            Assert.IsTrue(state.TransitionOn('d').Count() == 0);
        }

        #endregion //TransitionOnTest
    }
}
