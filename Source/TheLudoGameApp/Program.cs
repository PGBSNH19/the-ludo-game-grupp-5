using TheLudoGameEngine;
using System;
using System.Collections.Generic;

namespace TheLudoGameApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Välj antal spelare? ");
            int antalSpelare = int.Parse(Console.ReadLine());

            Game firstGame = new Game();
            for (int i = 0; i < antalSpelare; i++)
            {
                Console.WriteLine("Skriv ditt namn? ");
                string namnSpelare = Console.ReadLine();
                Console.WriteLine("Välj en färg: \n[0] Röd \n[1] Blå \n [2] Grön \n [3] Gul");
                int color = int.Parse(Console.ReadLine());

                firstGame.CreatePlayers(antalSpelare, namnSpelare, color);
            }

            //Test för att se om databasen lagrar som den ska
            //Game testGame = new Game();

            //for (int i = 0; i < 4; i++)
            //{
            //    var newPlayer = new Player();
            //    newPlayer.PlayerName = $"Spelare {i}";
            //    for (int y = 0; y < 4; y++)
            //    {
            //        var newToken = new Token();
            //        newToken.InNest = true;
            //        newPlayer.Tokens.Add(newToken);
            //    }

            //    //newPlayer.PlayerColor = colors[i];
            //    testGame.Players.Add(newPlayer);
            //}
            //TestGame(testGame);
        }

        public static void TestGame(Game testGame)
        {
            int count = 0;
            int rounds = 1;
            bool game = true;
            while (game == true)
            {
                ThrowDice(testGame.Players[count]);
                if (testGame.Players[count].Tokens[0].InGoal == true)
                {
                    Console.WriteLine($"{testGame.Players[count].PlayerName} won");
                    Console.WriteLine($"{testGame.Players[0].PlayerName} Token {testGame.Players[0].Tokens[0].GameBoardPosition}");
                    Console.WriteLine($"{testGame.Players[1].PlayerName} token {testGame.Players[1].Tokens[0].GameBoardPosition}");
                    Console.WriteLine($"{testGame.Players[2].PlayerName} token {testGame.Players[2].Tokens[0].GameBoardPosition}");
                    Console.WriteLine($"{testGame.Players[3].PlayerName} token {testGame.Players[3].Tokens[0].GameBoardPosition}");
                    game = false;
                }
                count++;
                if (count > testGame.Players.Count - 1)
                {
                    rounds++;
                    count = 0;
                }
            }
        }

        public static void ThrowDice(Player testPlayer)
        {
            int testDie = Die.ThrowDie();
            var tokens = Player.ChooseToken(testPlayer, testDie);
        }
    }
}