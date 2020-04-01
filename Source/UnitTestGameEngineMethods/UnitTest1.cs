

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheLudoGameEngine;

namespace UnitTestGameEngineMethods
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Token_MovmeToken_Forward_False()
        {
            var testToken = new Token();
            testToken.GameBoardPosition = 2;
            testToken.GameBoardPosition = testToken.MoveToken(5);
            Assert.IsFalse(testToken.GameBoardPosition == 8);
        }
        [TestMethod]
        public void Token_MovmeToken_Forward_True()
        {
            var testToken = new Token();
            testToken.GameBoardPosition = 2;
            testToken.GameBoardPosition = testToken.MoveToken(5);
            Assert.IsTrue(testToken.GameBoardPosition == 7);
        }

        [TestMethod]
        public void Token_MovmeToken_Backwards_False()
        {
            var test = new Token();
            test.GameBoardPosition = 44;
            test.GameBoardPosition = test.MoveToken(5);
            Assert.IsFalse(test.GameBoardPosition == 42);
        }

        [TestMethod]
        public void Token_MovmeToken_Backwards_True()
        {
            var test = new Token();
            test.GameBoardPosition = 44;
            test.GameBoardPosition = test.MoveToken(5);
            Assert.IsFalse(test.GameBoardPosition == 41);
        }

        [TestMethod]
        public void Game_CheckWinner_Returns_False()
        {
            var testGame = new Game();
            var testWinner = new Player();
            for(int i = 0; i<4; i++)
            {
                var testToken = new Token();
                if (i > 2)
                {
                    testToken.InGoal = true;
                    testWinner.Tokens.Add(testToken);
                }
                else
                {
                    testToken.InGoal = true;
                    testWinner.Tokens.Add(testToken);
                }                
            }
            testGame.Finished = testGame.CheckWinner(testWinner);
            Assert.IsTrue(testGame.Finished == true);
        }

    }


}
