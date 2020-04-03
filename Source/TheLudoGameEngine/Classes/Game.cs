using System;
using System.Collections.Generic;
using System.Linq;

namespace TheLudoGameEngine

{
    public class Game
    {
        public int GameID { get; set; }
        public bool Finished { get; set; }
        public int PlayerTurn { get; set; }
        public List<Player> Players { get; set; }

        public Game()
        {
            Players = new List<Player>();
        }

        public void CreatePlayers(string name, int color)
        {
            var newPlayer = new Player();
            newPlayer.PlayerName = name;
            newPlayer.PlayerColor = Enum.GetName(typeof(Colors), color);
            
            for(int i = 0; i < 1; i++)
            {
                var newToken = new Token();
                newToken.InNest = true;
                newToken.TokenColor = Enum.GetName(typeof(Colors), color);
                newPlayer.Tokens.Add(newToken);
            }

            Players.Add(newPlayer);
        }

        enum Colors
        {
            Red,
            Blue,
            Green,
            Yellow
        }

        public int CheckTurn()
        {
            PlayerTurn++;
            if(PlayerTurn > Players.Count - 1)
            {
                PlayerTurn = 0;
            }
            return PlayerTurn;
        }

        public bool CheckWinner(Player player)
        {
            if(player.Tokens.Where(p => p.InGoal == true).Count() == 1)
            {
                return this.Finished = true;
            }
            return this.Finished = false;
        }

        public static void ThrowDie(Player player)
        {
            var dice = new Die();
            dice.result = Die.ThrowDie();
        }


        public List<Token> TokensToMove(Player currentPlayer, int dieResult)
        {
            var tokensToPlay = new List<Token>();
            if (dieResult == 1 || dieResult == 6)
            {
                tokensToPlay.Add(currentPlayer.Tokens.Where(t => t.InNest == true).FirstOrDefault());
            }
            for (int i = 0; i < 1; i++)
            {
                if (currentPlayer.Tokens[i].InNest == false && currentPlayer.Tokens[i].InGoal == false)
                {
                    tokensToPlay.Add(currentPlayer.Tokens[i]);
                }
            }
            return tokensToPlay;
        }

        public void RunMovement(Game game, int die)
        {
            game.Players[game.PlayerTurn].Tokens[0].InNest = false;
            game.Players[game.PlayerTurn].Tokens[0].MoveToken(die);
            if(game.Players[game.PlayerTurn].Tokens[0].HasFinished() != true)
            {
                game.CheckTurn();
            }
            game.CheckWinner(game.Players[game.PlayerTurn]);


        }
    }
}