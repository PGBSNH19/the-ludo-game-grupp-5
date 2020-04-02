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

        public static List<string> colors = new List<string> { "röd", "blå", "grön", "gul" };

        public Game()
        {
            Players = new List<Player>();
        }

        public void CreatePlayers(string namnSpelare, int color)
        {
            var createNewPlayer = new Player();
            Players.Add(createNewPlayer);
            createNewPlayer.PlayerName = namnSpelare;
            createNewPlayer.PlayerColor = colors[color];
            colors.RemoveAt(color);
            for (int y = 0; y < 4; y++)
            {
                var createToken = new Token();
                createToken.InNest = true;
                createNewPlayer.Tokens.Add(createToken);
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