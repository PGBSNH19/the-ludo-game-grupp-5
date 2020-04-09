using System;
using TheLudoGameEngine;
using Xunit;

namespace TheLudoGameXTest
{
    public class UnitTest1
    {

        [Fact]
        public void Token_MoveFromStep43AndForward2_InGoal()
        {
            //Arrange
            var testToken = new Token { StepsCounter = 43 };
            
            //Act
            testToken.CountTokenSteps(testToken, 2);
            testToken.TokenInGoal();

            //Assert
            Assert.True(testToken.InGoal);
        }
        
        [Fact]
        public void Token_MoveFromGameBoardToGoalLine_True()
        {
            //Arrange
            var testToken = new Token { StepsCounter = 44};
            

            //Act
            testToken.CountTokenSteps(testToken, 5);
            testToken.AtEndLap();

            Assert.True(testToken.InEndLap);

        }

        [Fact]

        public void Token_GameBoardPosition36And5ForwardIntoNewLap_GameBoardPosition1()
        {
            //Arrange
            var testToken = new Token { GameBoardPosition = 36 };
            
            //Act
            testToken.CountGameBordPosition(5);

            Assert.Equal(1, testToken.GameBoardPosition);
        }
        
        [Fact]
        public void YellowToken_GameBoardPosition30And6Forward_GameBoardPosition36()
        {
            //Arrange
            var testToken = new Token { TokenColor = "Yellow" };

            //Act
            testToken.TokensStartPostion(testToken);
            testToken.CountGameBordPosition(6);

            //Assert
            Assert.Equal(36, testToken.GameBoardPosition);
        }
        [Fact]
        public void Token_MovmeToken_FromStep2And5ForwardToStep7_False()
        {
            Token testToken = new Token { StepsCounter = 2 };
            testToken.CountTokenSteps(testToken, 5);
            Assert.Equal(8, testToken.StepsCounter);
        }

        [Fact]
        public void Token_MovmeToken_FromStep2And5Forward_Step7()
        {
            var testToken = new Token { StepsCounter = 2 };
            testToken.CountTokenSteps(testToken, 5);
            Assert.Equal(7, testToken.StepsCounter);
        }

        [Fact]
        public void MoveToken_FromPostion44_ToPosition42_False()
        {
            Token testToken = new Token { StepsCounter = 44 };
            testToken.CountTokenSteps(testToken, 5);
            Assert.Equal(42, testToken.StepsCounter);
        }

        [Fact]
        public void Token_MoveToken_BackwardsFromGoal_True()
        {
            Token testToken = new Token { StepsCounter = 44 };
            testToken.CountTokenSteps(testToken, 5);
            Assert.Equal(41, testToken.StepsCounter);
        }

        [Fact]
        public void Game_CheckWinner_True()
        {
            //Arrange
            Game testGame = new Game();
            testGame.CreatePlayer("Testname", 0);
            testGame.Players[0].Tokens[0].InGoal = true;
            testGame.Players[0].Tokens[1].InGoal = true;
            testGame.Players[0].Tokens[2].InGoal = true;
            testGame.Players[0].Tokens[3].InGoal = true;

            //Act
            testGame.CheckForWinner(testGame.Players[0]);
            
            //Assert
            Assert.True(testGame.Finished);
        }
    }
}