using System;
using System.Collections.Generic;

namespace TheLudoGame
{
    public class Program
    {
        private static void Main(string[] args)
        {
            List<string> colors = new List<string> { "röd", "blå", "grön", "gul" };
            Game testGame = new Game();

            Console.WriteLine("Chose how many players: ");
            int antalSpelare = int.Parse(Console.ReadLine());
            for (int i = 1; i <= antalSpelare; i++)
            {
                var newPlayer = new Player();
                Console.WriteLine($"Skriv ditt namn spelare: {i}");
                newPlayer.PlayerName = Console.ReadLine();
                Console.WriteLine("chose color");
                for (int x = 0; x < colors.Count; x++)
                {
                    Console.WriteLine($"{x} , {colors[x]}");
                }
                int colorChose = int.Parse(Console.ReadLine());
                newPlayer.PlayerColor = colors[colorChose];
                testGame.Players.Add(newPlayer);
                colors.RemoveAt(colorChose);
                Console.Clear();
            }
            int testDie = ThrowDie();
        }

        public static int ThrowDie()
        {
            Random DieThrow = new Random();

            int result = DieThrow.Next(1, 7);

            return result;
        }
    }

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

    public class Player
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public string PlayerColor { get; set; }
        public List<Token> Tokens { get; set; }
    }

    public class Token
    {
        public int TokenID { get; set; }
        public int GameBoardPosition { get; set; }
        public int EndLinePosition { get; set; }
        public bool AtEndLine { get; set; }
        public bool InGoal { get; set; }
    }
}