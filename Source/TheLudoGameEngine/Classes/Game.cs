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

        public List<Player> CreatePlayers(int amountOfPlayers)
        {
            if (amountOfPlayers > 4 || amountOfPlayers < 2)
            {
                throw new Exception("The amount of players needs to be between 2-4");
            }
            else
            {
                for (int i = 0; i < amountOfPlayers; i++)
                {
                    var createNewPlayer = new Player();
                    this.Players.Add(createNewPlayer);
                }
                return this.Players;
            }
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

        //public static AutoSave()
        //{
        //}

        public bool CheckWinner(Player player)
        {
            var checkW = player.Tokens.Where(p => p.InGoal == true).ToList();
            if(checkW.Count == 4)
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