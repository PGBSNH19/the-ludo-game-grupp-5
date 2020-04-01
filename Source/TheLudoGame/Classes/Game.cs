using System.Collections.Generic;

namespace TheLudoGame
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