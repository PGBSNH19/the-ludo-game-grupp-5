using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TheLudoGameEngine
{
    public class Engine : Game
    {
        private LudoContext myContext = new LudoContext();
        public Token tokenToKnockOut;

        //Simulates a diethrow
        public int ThrowDie()
        {
            return new Random().Next(1, 7);
        }

        /*Returns a list of movable tokens, depending on the outcome of the diethrow and/or current player tokens position on the board
          LINQ explanation:
          Return token if the outcome of the diethrow is 1 or 6 and the token position is in the nest
          Return token if the token is on the game board (not in the nest or in goal), dont care about the outcome of the diethrow
          Don't return token if the token are in goal.
       */

        public List<Token> MovableTokens(Player currentPlayer, int dieResult)
        {
            return currentPlayer.Tokens.Where(t => (!t.InGoal && !t.InNest)
                                             || ((dieResult == 1 || dieResult == 6)
                                             && t.InNest
                                             && !t.InGoal)).ToList();
        }

        public Token ChooseToken(List<Token> tokensToPlay, Token tokenToMove)
        {
            return tokensToPlay.FirstOrDefault(t => t == tokenToMove);
        }

        //Runs the token movment action and calculate the tokens new position/state
        public void RunPlayerTurn(Token currentToken, int die, Game game, Player currentPlayer)
        {
            if (currentToken.InNest)
            {
                currentToken.InNest = false;
            }

            currentToken.CountTokenSteps(currentToken, die);
            currentToken.AtEndLap();

            currentToken.CountTokenGameBordPosition(die);
            KnockOutAnotherToken(currentToken, game);

            currentToken.TokenInGoal();
            game.CheckForWinner(currentPlayer);

            if (die != 6 && !game.Finished)
            {
                game.UpdateTurnAndRound();
            }
        }

        //Run the method to update the games player turn and round if a player can't move any token
        public void RunGameUpdate(Game game)
        {
            game.UpdateTurnAndRound();
        }

        //Returns a list of saved unfinished games
        public List<Game> LoadPreviousGamesFromDataBase()
        {
            return myContext.Games.Include(g => g.Players).ThenInclude(p => p.Tokens).Where(g => g.Finished != true).ToList();
        }

        //Returns a list of finished games
        public List<Game> LoadAllFinishedGamesFromDataBase()
        {
            return myContext.Games.Include(g => g.Players).ThenInclude(p => p.Tokens).Where(g => g.Finished != false).ToList();
        }

        //Saves the game
        public void SaveGameToDataBase(Game game)
        {
            game.LastSaved = DateTime.Now;
            using (var saveContext = new LudoContext())
            {
                try
                {
                    myContext.Games.Update(game);
                    myContext.SaveChanges();
                }
                catch
                {
                    myContext.Games.Add(game);
                    myContext.SaveChanges();
                }
            }
        }

        public void KnockOutAnotherToken(Token currentToken, Game game)
        {
            tokenToKnockOut = game.Players.SelectMany(t => t.Tokens).Distinct().Except(game.Players[game.PlayerTurn].Tokens).
            Where(t => t.GameBoardPosition == currentToken.GameBoardPosition
            && !t.InGoal
            && !t.InNest
            && !t.InEndLap).FirstOrDefault();

            if (tokenToKnockOut != null)
            {
                tokenToKnockOut.InNest = true;
                tokenToKnockOut.TokenStartGameBoardPosition(tokenToKnockOut);
                tokenToKnockOut.StepCounter = 0;
            }
        }
    }
}