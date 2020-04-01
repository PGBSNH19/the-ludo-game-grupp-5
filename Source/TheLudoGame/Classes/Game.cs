using System;
using System.Collections.Generic;

namespace GameEngine

{
    public class Game
    {
        public int GameID { get; set; }
        public bool Finished { get; set; }
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


        public Player CheckTurn(int index)
        {
            return this.Players[index];
        }

        //public static AutoSave()
        //{

        //}

        public bool CheckWinner()
        {
            return this.Finished;
        }

        //public static LogWinner()
        //{

        //}

    }
}