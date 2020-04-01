using GameEngine;
using System;
using System.Collections.Generic;

namespace TheLudoGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Test för att se om databasen lagrar som den ska
            List<string> colors = new List<string> { "röd", "blå", "grön", "gul" };
            Game testGame = new Game();

            //Console.WriteLine("Hur många spelare?: ");
            //int antalSpelare = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 2; i++)
            {
                var newPlayer = new Player();
                //Console.WriteLine($"Skriv ditt namn spelare: {i}");
                newPlayer.PlayerName = $"Spelare {i}";

                var newToken = new Token();
                newPlayer.Tokens.Add(newToken);

                newPlayer.PlayerColor = colors[i];
                testGame.Players.Add(newPlayer);
                colors.RemoveAt(i);
                Console.Clear();
            }
            TestGame(testGame);
        }

        public static void TestGame(Game testGame)
        {
            int count = 0;
            while (true)
            {
                ThrowDice(testGame.Players[count]);

                count++;
                if (count > testGame.Players.Count - 1)
                {
                    count = 0;
                }
            }
        }

        public static void ThrowDice(Player testPlayer)
        {
            testPlayer.Tokens[0].MoveToken(Die.ThrowDie());
        }
    }


}
