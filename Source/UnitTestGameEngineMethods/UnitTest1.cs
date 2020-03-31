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
            int testResult = TokenMovement.ThrowDie();
            Assert.IsTrue(testResult >= 1 && testResult <= 7);
        }
    }
}
