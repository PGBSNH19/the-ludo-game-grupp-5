using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheLudoGameEngine
{
    public class Engine : Game
    {
        MyContext myContext = new MyContext();
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
            return currentPlayer.Tokens.Where(t => (t.InGoal == false && t.InNest == false) || ((dieResult == 1 || dieResult == 6) && t.InNest == true && t.InGoal == false)).ToList();
        }


        public Token ChooseToken(List<Token> tokensToPlay, Token tokenID)
        {
            return tokensToPlay.Where(s => s == tokenID).FirstOrDefault();
        }


        //Runs the token movment action and calculate the tokens new position/state
        public void RunMovementAction(Token currentToken, int die)
        {
            if (currentToken.InNest != false)
            {
                currentToken.InNest = false;
            }
            currentToken.MoveToken(die);
            currentToken.HasFinished();
        }

        //Runs a gameupdate as calculate which playerturn is next, count rounds and control if the currentplayer have won the game
        public void RunGameUpdate(Game game, Player currentPlayer)
        {
            game.CheckWinner(currentPlayer);
            if (game.Finished != true)
            {
                game.UpdateTurnAndRound();
            }
        }


        //Returns a list of saved unfinished games
        public List<Game> LoadPreviousGames()
        {
            return myContext.Games.Include(g => g.Players).ThenInclude(p => p.Tokens).Where(g => g.Finished != true).ToList();
        }


        //Saves the game
        public void SaveGame(Game game)
        {
            game.LastSaved = UpdateCurrentTime();

            using (var saveContext = new MyContext())
            {
                try
                {
                    saveContext.Games.Update(game);
                    saveContext.SaveChanges();
                }
                catch
                {
                    saveContext.Games.Add(game);
                    saveContext.SaveChanges();
                }
            }
        }
       
    }
}