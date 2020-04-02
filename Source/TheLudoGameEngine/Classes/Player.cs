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
        public List<Token> Tokens { get; set; }

        public Player()
        {
            Tokens = new List<Token>();
        }

        //public static List<Token> ChooseToken(Player currentPlayer, int dieResult)
        //{
        //    var tokensToPlay = new List<Token>();
        //    if(dieResult == 1 || dieResult == 6)
        //    {
        //        tokensToPlay.Add(currentPlayer.Tokens.Where(t => t.InNest == true).FirstOrDefault());
        //    }
        //    for(int i = 0; i < 4; i++)
        //    {
        //        if(currentPlayer.Tokens[i].InNest == false && currentPlayer.Tokens[i].InGoal == false)
        //        {
        //            tokensToPlay.Add(currentPlayer.Tokens[i]);
        //        }
        //    }
        //    return tokensToPlay;
        //}

        //public static SaveGame()
        //{
        //}
    }
}