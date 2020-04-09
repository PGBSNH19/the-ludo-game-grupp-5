using System;
using System.Linq;
using TheLudoGameEngine;
using Xunit;

namespace TheLudoGameXTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(16)]
        public void KnockOutAnotherToken_KnockoutOtherColorInSamePostion(int position)
        {
            Game game = new Game();
            Engine engine = new Engine();

            game.CreatePlayer("player1", 0);
            game.Players[0].Tokens[0].GameBoardPosition = 16;
            game.Players[0].Tokens[0].InNest = false;

            game.CreatePlayer("player2", 1);
            game.Players[1].Tokens[0].GameBoardPosition = position;
            game.Players[1].Tokens[0].InNest = false;

            engine.KnockOutAnotherToken(game.Players[0].Tokens[0], game);

            Assert.True(game.Players[1].Tokens[0].InNest);
        }

        [Fact]
        public void Token_GameBoardPosition36And5Forward_GameBoardPosition1()
        {
            var testToken = new Token();
            testToken.GameBoardPosition = 36;
            testToken.CountGameBordPosition(5);

            Assert.Equal(1, testToken.GameBoardPosition);
        }

        [Fact]
        public void YellowToken_GameBoardPosition30And6Forward_GameBoardPosition36()
        {
            //Arrange
            var testToken = new Token();

            //Act
            testToken.TokenColor = "Yellow";
            testToken.TokensStartPostion(testToken);
            testToken.CountGameBordPosition(6);

            //Assert
            Assert.Equal(36, testToken.GameBoardPosition);
        }

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
        public void MoveToken_FromPostion44_ToPosition42()
        {
            Token testToken = new Token();
            testToken.StepsCounter = 44;

            testToken.CountTokenSteps(testToken, 5);
            Assert.Equal(42, testToken.StepsCounter);
        }

        [Fact]
        public void Token_MoveToken_BackwardsFromGoal_True()
        {
            Token testToken = new Token();
            testToken.StepsCounter = 44;
            testToken.CountTokenSteps(testToken, 5);
            Assert.Equal(41, testToken.StepsCounter);
        }

        [Fact]
        public void Game_CheckWinner_Returns_False()
        {
            Game testGame = new Game();
            Player testWinner = new Player();
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
            Assert.True(testGame.Finished);
        }
    }
}