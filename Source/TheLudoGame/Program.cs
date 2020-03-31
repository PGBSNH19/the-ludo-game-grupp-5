using System;
using System.Collections.Generic;

namespace TheLudoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Game
    {
        int GameID { get; set; }
        bool Finished { get; set; }
        List<Player> Players { get; set; }
    }

    class Player
    {
        int PlayerID { get; set; }
        string PlayerName { get; set; }
        string PlayerColor { get; set; }
        List<Token> Tokens { get; set; }
    }

    class Token
    {
        int TokenID { get; set; }
        int GameBoardPosition { get; set; }
        int EndLinePosition { get; set; }
        bool AtEndLine { get; set; }
        bool InGoal { get; set; }
    }
}
