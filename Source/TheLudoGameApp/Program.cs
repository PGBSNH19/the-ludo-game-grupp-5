using TheLudoGameEngine;
using System;
using System.Collections.Generic;

namespace TheLudoGameApp
{
    public class Program
    {
        public static int antalSpelare = 0;

        public static Engine firstGame = new Engine();

        public static void Main(string[] args)
        {
            CreateGame();
        }

        public static void CreateGame()
        {
            bool loop = true;

            while (loop)
            {
                Console.WriteLine("Välj antal spelare? ");
                antalSpelare = int.Parse(Console.ReadLine());
                if (antalSpelare > 4 || antalSpelare < 2)
                {
                    Console.WriteLine("The amount of players needs to be between 2-4");
                }
                else
                {
                    loop = false;
                }
            }
            for (int i = 0; i < antalSpelare; i++)
            {
                Console.WriteLine("Skriv ditt namn? ");
                string namnSpelare = Console.ReadLine();
                Console.WriteLine($"Välj en färg:");
                for (int x = 0; x < Game.colors.Count; x++)
                {
                    Console.WriteLine($"{x} {Game.colors[x]}");
                }
                int color = int.Parse(Console.ReadLine());

                firstGame.CreatePlayers(namnSpelare, color);
            }
            do
            {
                if (firstGame.Finished == true)
                {
                    loop = false;
                }
                for (int i = 0; i < antalSpelare; i++)
                {
                    Console.WriteLine($"Det är spelare {firstGame.Players[i]} tur");
                }
                loop = false;
            } while (loop);
        }

        public static void StartGame()
        {
            //bool loop = true;
        }

        //public static void TestGame(Game testGame)
        //{
        //    int count = 0;
        //    int rounds = 1;
        //    bool game = true;
        //    while (game == true)
        //    {
        //        ThrowDice(testGame.Players[count]);
        //        if (testGame.Players[count].Tokens[0].InGoal == true)
        //        {
        //            Console.WriteLine($"{testGame.Players[count].PlayerName} won");
        //            Console.WriteLine($"{testGame.Players[0].PlayerName} Token {testGame.Players[0].Tokens[0].GameBoardPosition}");
        //            Console.WriteLine($"{testGame.Players[1].PlayerName} token {testGame.Players[1].Tokens[0].GameBoardPosition}");
        //            Console.WriteLine($"{testGame.Players[2].PlayerName} token {testGame.Players[2].Tokens[0].GameBoardPosition}");
        //            Console.WriteLine($"{testGame.Players[3].PlayerName} token {testGame.Players[3].Tokens[0].GameBoardPosition}");
        //            game = false;
        //        }
        //        count++;
        //        if (count > testGame.Players.Count - 1)
        //        {
        //            rounds++;
        //            count = 0;
        //        }
        //    }
        //}

        //public static void ThrowDice(Player testPlayer)
        //{
        //    int testDie = Die.ThrowDie();
        //    //var tokens = Player.ChooseToken(testPlayer, testDie);
        //}
    }
}