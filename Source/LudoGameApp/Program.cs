using GameEngine;
using System;
using System.Collections.Generic;

namespace LudoGameApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test för att se om databasen lagrar som den ska
            List<string> colors = new List<string> { "röd", "blå", "grön", "gul" };
            Game testGame = new Game();

            
            for (int i = 0; i < 4; i++)
            {
                var newPlayer = new Player();  
                newPlayer.PlayerName = $"Spelare {i}";
                var newToken = new Token();
                newPlayer.Tokens.Add(newToken);
                newPlayer.PlayerColor = colors[i];
                testGame.Players.Add(newPlayer);
                
               
            }
            TestGame(testGame);
        }

        public static void TestGame(Game testGame)
        {
            int count = 0;
            int rounds = 1;
            bool game = true;
            while(game == true)
            {
                ThrowDice(testGame.Players[count]);
                if(testGame.Players[count].Tokens[0].InGoal == true)
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
            testPlayer.Tokens[0].MoveToken(Die.ThrowDie());
            testPlayer.Tokens[0].HasFinished();
        }
    
    }
}
