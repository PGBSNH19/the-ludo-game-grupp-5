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