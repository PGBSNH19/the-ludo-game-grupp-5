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
    }
}