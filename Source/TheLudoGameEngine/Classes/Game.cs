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

        //    List<string> colors = new List<string> { "röd", "blå", "grön", "gul" };
        //    Game testGame = new Game();

        //        for (int i = 0; i< 4; i++)
        //        {
        //            var newPlayer = new Player();
        //    newPlayer.PlayerName = $"Spelare {i}";
        //            for(int y = 0; y< 4; y++)
        //            {
        //                var newToken = new Token();
        //    newToken.InNest = true;
        //                newPlayer.Tokens.Add(newToken);
        //            }

        //newPlayer.PlayerColor = colors[i];
        //            testGame.Players.Add(newPlayer);
        //        }

        public void CreatePlayers(int antalSpelare, string namnSpelare, int color)
        {
            List<string> colors = new List<string> { "röd", "blå", "grön", "gul" };

            // lägg till namn färg och token
            if (antalSpelare > 4 || antalSpelare < 2)
            {
                throw new Exception("The amount of players needs to be between 2-4");
            }
            else
            {
                    var createNewPlayer = new Player();
                    Players.Add(createNewPlayer);
                    createNewPlayer.PlayerName = namnSpelare;
                    createNewPlayer.PlayerColor = colors[color];
            }
        }

        public int CheckTurn()
        {
            PlayerTurn++;
            if (PlayerTurn > Players.Count - 1)
            {
                PlayerTurn = 0;
            }
            return PlayerTurn;
        }

        //public static AutoSave()
        //{
        //}

        public bool CheckWinner(Player player)
        {
            var checkW = player.Tokens.Where(p => p.InGoal == true).ToList();
            if (checkW.Count == 4)
            {
                this.Finished = true;
            }
            return this.Finished;
        }

        //public static LogWinner()
        //{
        //}
    }
}