using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TheLudoGameEngine
{
    public class Engine : Game
    {
        private LudoContext myContext = new LudoContext();

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

        public List<Token> TokensToMove(Player currentPlayer, int dieResult)
        {
            var moveableTokens = currentPlayer.Tokens.Where(t => (t.InGoal == false && t.InNest == false) ||
                                              ((dieResult == 1 || dieResult == 6) && t.InNest == true
                                              && t.InGoal == false)).ToList();

            return null;
        }

        public Token ChooseToken(List<Token> tokensToPlay, Token tokenID)
        {
            return tokensToPlay.Where(t => t == tokenID).FirstOrDefault();
        }

        //Runs the token movment action and calculate the tokens new position/state
        public void RunMovementAction(Token currentToken, int die, Game game, Player currentPlayer)
        {
            if (currentToken.InNest != false)
            {
                currentToken.InNest = false;
            }

            currentToken.CountTokenSteps(currentToken, die);
            currentToken.AtEndLap();

            if (currentToken.InEndLap != true)
            {
                currentToken.CountGameBordPosition(die);
                KnockOutAnotherToken(currentToken, game);
            }

            currentToken.TokenInGoal();
        }

        //Runs a gameupdate as calculate which playerturn is next, count rounds and control if the currentplayer have won the game
        public void RunGameUpdate(Game game, Player currentPlayer)
        {
            game.CheckForWinner(currentPlayer);
            if (game.Finished != true)
            {
                game.UpdateTurnAndRound();
            }
        }

        //Returns a list of saved unfinished games
        public List<Game> ShowPreviousGames()
        {
            return myContext.Games.Include(g => g.Players).ThenInclude(p => p.Tokens).Where(g => g.Finished != true).ToList();
        }

        //Load the selected game
        public Game LoadPreviousGame(List<Game> prevGames, int gameID)
        {
            return prevGames.Where(g => g.GameID == gameID).FirstOrDefault();
        }

        //Saves the game
        public void SaveGame(Game game)
        {
            //game.LastSaved = DateTime.Now;
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
            var tokenToKnockOut = game.Players.SelectMany(t => t.Tokens).Distinct().Except(game.Players[game.PlayerTurn].Tokens).
            Where(t => t.GameBoardPosition == currentToken.GameBoardPosition
            && t.InGoal == false
            && t.InNest == false
            && t.InEndLap == false).FirstOrDefault();

            if (tokenToKnockOut != null)
            {
                tokenToKnockOut.InNest = true;
                tokenToKnockOut.TokensStartPostion(tokenToKnockOut);
                tokenToKnockOut.StepsCounter = 0;
                //Console.WriteLine($"{currentToken.TokenColor} {currentToken.TokenNumber} knocked out {tokenToKnockOut.TokenColor} {tokenToKnockOut.TokenNumber}");
                //Console.ReadKey();
            }
        }
    }
}