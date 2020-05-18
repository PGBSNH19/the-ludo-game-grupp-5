using System;
using System.Collections.Generic;
using System.Text;
using TheLudoGameEngine;
using Xunit;

namespace TheLudoGameXTest
{
    public class TestGameEngine
    {

        [Fact]
        public void RunPlayerTurn_Player1Token0MovesForward2OnGameBoardPositionKnocksOutPlayer2Token_Player2TokenInNestTrue()
        {

            Engine engine = new Engine();
            Game game = new Game();
            game.CreatePlayer("Player1", 0);
            game.CreatePlayer("Player 2", 1);

            game.Players[0].Tokens[0].InNest = false;
            game.Players[0].Tokens[0].InGoal = false;
            game.Players[0].Tokens[0].GameBoardPosition = 10;

            game.Players[1].Tokens[0].InNest = false;
            game.Players[1].Tokens[0].InGoal = false;
            game.Players[1].Tokens[0].GameBoardPosition = 12;

            engine.RunPlayerTurn(game.Players[0].Tokens[0], 2, game, game.Players[0]);

            Assert.True(game.Players[1].Tokens[0].InNest);
            Assert.Equal(12, game.Players[0].Tokens[0].GameBoardPosition);

        }

        [Fact]
        public void RunPlayerTurn_TokensInGoal3And1TokenMoveFromStep43And2ForwardInGoal_GameFinishedTrue()
        {
            Engine engine = new Engine();
            Game game = new Game();
            game.CreatePlayer("Player1", 0);
            
            game.Players[0].Tokens[0].InNest = false;
            game.Players[0].Tokens[0].InGoal = true;

            
            game.Players[0].Tokens[1].InNest = false;
            game.Players[0].Tokens[1].InGoal = true;

            
            game.Players[0].Tokens[2].InNest = false;
            game.Players[0].Tokens[2].InGoal = true;

            
            game.Players[0].Tokens[3].InNest = false;
            game.Players[0].Tokens[3].InGoal = false;
            game.Players[0].Tokens[3].StepCounter = 43;

            engine.RunPlayerTurn(game.Players[0].Tokens[3], 2, game, game.Players[0]);

            Assert.True(game.Finished);
            Assert.True(game.Players[0].Winner);
            Assert.Equal(45, game.Players[0].Tokens[3].StepCounter);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(6)]
        public void TokensToMove_TokensOnBoard3InNest1DieResult6_4MovableTokens(int dieNumber)
        {
            Game game = new Game();
            Engine engine = new Engine();

            game.CreatePlayer("Player1", 0);
            game.Players[0].Tokens[0].GameBoardPosition = 0;
            game.Players[0].Tokens[0].InNest = true;
            game.Players[0].Tokens[0].InGoal = false;

            game.Players[0].Tokens[1].GameBoardPosition = 10;
            game.Players[0].Tokens[1].InNest = false;
            game.Players[0].Tokens[1].InGoal = false;

            game.Players[0].Tokens[2].GameBoardPosition = 16;
            game.Players[0].Tokens[2].InNest = false;
            game.Players[0].Tokens[2].InGoal = false;

            game.Players[0].Tokens[3].GameBoardPosition = 19;
            game.Players[0].Tokens[3].InNest = false;
            game.Players[0].Tokens[3].InGoal = false;

            var result = engine.MovableTokens(game.Players[0], dieNumber).Count;

            Assert.Equal(4, result);
        }

        [Fact]
        public void TokensToMove_TokensOnBoard1InNest1InGoal2DieResult6_TokensToMove2()
        {
            Game game = new Game();
            Engine engine = new Engine();

            game.CreatePlayer("Player1", 0);

            game.Players[0].Tokens[0].InNest = true;
            game.Players[0].Tokens[0].InGoal = false;

            game.Players[0].Tokens[1].InNest = false;
            game.Players[0].Tokens[1].InGoal = false;

            game.Players[0].Tokens[2].InNest = false;
            game.Players[0].Tokens[2].InGoal = true;

            game.Players[0].Tokens[3].InNest = false;
            game.Players[0].Tokens[3].InGoal = true;

            var result = engine.MovableTokens(game.Players[0], 6).Count;

            Assert.Equal(2, result);
        }

        [Theory]
        [InlineData(16)]
        public void KnockOutAnotherToken_Player1TokenKnocksOutPlayer2Token_Player2TokenInNest(int position)
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

        [Theory]
        [InlineData(16)]
        public void KnockOutAnotherToken_CantKnockoutPlayerIfInEndLap_False(int position)
        {
            Game game = new Game();
            Engine engine = new Engine();
            game.CreatePlayer("player1", 0);
            game.Players[0].Tokens[0].GameBoardPosition = 16;
            game.Players[0].Tokens[0].InNest = false;
            game.Players[0].Tokens[0].InEndLap = false;

            game.CreatePlayer("player2", 1);
            game.Players[1].Tokens[0].GameBoardPosition = position;
            game.Players[1].Tokens[0].InNest = false;
            game.Players[1].Tokens[0].InEndLap = true;

            engine.KnockOutAnotherToken(game.Players[0].Tokens[0], game);

            Assert.False(game.Players[1].Tokens[0].InNest);
        }
    }
}