

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheLudoGameEngine;

namespace UnitTestGameEngineMethods
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestingDieThrow()
        {
            int testResult = Die.ThrowDie();
            Assert.IsTrue(testResult >= 1 && testResult <= 6);
        }

        [TestMethod]
        public void TestingTokenMovmentForward()
        {
            var test = new Token();
            test.GameBoardPosition = test.MoveToken(5);
            Assert.IsFalse(test.GameBoardPosition == 36);
        }

        [TestMethod]
        public void TestingTokenMovmentBackwards()
        {
            var test = new Token();
            test.GameBoardPosition = 44;
            test.GameBoardPosition = test.MoveToken(5);
            Assert.IsFalse(test.GameBoardPosition == 42);
        }

    }


}
