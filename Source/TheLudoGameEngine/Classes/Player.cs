using System.Collections.Generic;
using System.Linq;

namespace TheLudoGameEngine
{
    public class Player
    {
        public int PlayerID { get; set; }
        public Game Game { get; set; }
        public string PlayerName { get; set; }
        public string PlayerColor { get; set; }
        public bool Winner { get; set; }
        public List<Token> Tokens { get; set; }

        public Player()
        {
            Tokens = new List<Token>();
        }

        
    }
}