using System;
using TheLudoGameEngine;
using Xunit;

namespace TheLudoGameXTest
{
    public class UnitTest1
    {
        [Fact]
        public void Token_MovmeToken_FromPostion2And5Forward_False()
        {
            Token testToken = new Token();
            testToken.StepsCounter = 2;
            testToken.CountTokenSteps(testToken, 5);
            Assert.Equal(8, testToken.StepsCounter);
        }

        [Fact]
        public void Token_MovmeToken_FromPosition2And5Forward_Position7()
        {
            var testToken = new Token();
            testToken.StepsCounter = 2;
            testToken.CountTokenSteps(testToken, 5);
            Assert.Equal(7, testToken.StepsCounter);
        }

        [Fact]
        public void Token_MoveToken_BackwardsFromGoal_False()
        {
            var testToken = new Token();
            testToken.StepsCounter = 44;
            testToken.CountTokenSteps(testToken, 5);
            Assert.IsFalse(testToken.StepsCounter == 42);
        }

        [Fact]
        public void Token_MoveToken_BackwardsFromGoal_True()
        {
            var testToken = new Token();
            testToken.StepsCounter = 44;
            testToken.CountTokenSteps(testToken, 5);
            Assert.IsFalse(testToken.StepsCounter == 41);
        }

        [Fact]
        public void Game_CheckWinner_Returns_False()
        {
            var testGame = new Game();
            var testWinner = new Player();
            for (int i = 0; i < 4; i++)
            {
                var testToken = new Token();
                if (i > 2)
                {
                    testToken.InGoal = false;
                    testWinner.Tokens.Add(testToken);
                }
                else
                {
                    testToken.InGoal = true;
                    testWinner.Tokens.Add(testToken);
                }
            }
            testGame.Finished = testGame.CheckForWinner(testWinner);
            Assert.IsTrue(testGame.Finished == true);
        }
    }
}
}