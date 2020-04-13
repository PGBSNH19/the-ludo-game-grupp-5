using System;
using System.Collections.Generic;
using System.Text;
using TheLudoGameEngine;
using Xunit;

namespace TheLudoGameXTest
{
    public class TestTokenStates
    {
        [Theory]
        [InlineData("Red", 40)]
        [InlineData("Blue", 10)]
        [InlineData("Green", 20)]
        [InlineData("Yellow", 30)]
        public void Token_StartPositionsDependingOnColor(string color, int startPostion)
        {
            Token testToken = new Token { TokenColor = color };

            testToken.TokensStartPostion(testToken);

            Assert.Equal(startPostion, testToken.GameBoardPosition);
        }

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
            var testToken = new Token { StepsCounter = 38 };

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
        public void MoveToken_FromStep2And5Forward_Step7()
        {
            var testToken = new Token { StepsCounter = 2 };
            testToken.CountTokenSteps(testToken, 5);
            Assert.Equal(7, testToken.StepsCounter);
        }

        [Fact]
        public void MoveToken_FromStep44And1StepForwardAnd4StepsBackwards_Step41()
        {
            Token testToken = new Token { StepsCounter = 44 };
            testToken.CountTokenSteps(testToken, 5);
            Assert.Equal(41, testToken.StepsCounter);
        }
    }
}