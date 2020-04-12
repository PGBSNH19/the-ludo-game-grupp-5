using TheLudoGameEngine;
using Xunit;

namespace TheLudoGameXTest
{
    public class TestGameStates
    {

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

        [Fact]
        public void Token_InGoal_False()
        {
            Token testToken = new Token { StepsCounter = 44 };
            testToken.TokenInGoal();
            Assert.False(testToken.InGoal);
        }

        [Fact]
        public void Game_UpdateTurn_0To1()
        {
            //Arrange
            Game testGame = new Game();
            testGame.CreatePlayer("player1", 1);
            testGame.CreatePlayer("player2", 2);
            testGame.PlayerTurn = 0;
            //Act
            testGame.UpdateTurnAndRound();

            //Assert
            Assert.Equal(1, testGame.PlayerTurn);
        }
        [Fact]
        public void Game_UpdateRound_1To2()
        {
            //Arrange
            Game testGame = new Game();
            testGame.CreatePlayer("player1", 1);
            testGame.CreatePlayer("player2", 2);
            testGame.PlayerTurn = 1;
            testGame.Round = 1;
            //Act
            testGame.UpdateTurnAndRound();

            //Assert
            Assert.Equal(2, testGame.Round);
        }

        [Fact]
        public void Game_PlayerTurnFrom2To0_GamePlayerTurn0()
        {
            Game testGame = new Game();
            testGame.CreatePlayer("testplayer1", 1);
            testGame.CreatePlayer("testplayer2", 2);
            testGame.CreatePlayer("testplayer3", 3);

            testGame.PlayerTurn = 2;
            testGame.UpdateTurnAndRound();

            Assert.Equal(0, testGame.PlayerTurn);
        }
        [Fact]
        public void Game_CreatePlayerGets4Tokens_PlayerTokenCount4()
        {
            Game testGame = new Game();
            testGame.CreatePlayer("Test player", 0);

            Assert.Equal(4, testGame.Players[0].Tokens.Count);
        }
    }
}