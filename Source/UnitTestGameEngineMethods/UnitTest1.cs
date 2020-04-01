using GameEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;


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
            int testForwardPosition = Die.MoveToken(31, 5);
            Assert.IsTrue(testForwardPosition == 36);
        }

        [TestMethod]
        public void TestingTokenMovmentBackwards()
        {
            int testBackwardPosition = Die.MoveToken(43, 5);
            Assert.IsTrue(testBackwardPosition == 42);
        }

    }


}
