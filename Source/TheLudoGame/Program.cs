using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TheLudoGame.Classes;

namespace TheLudoGame
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //Test för att se om databasen lagrar som den ska
            List<string> colors = new List<string> { "röd", "blå", "grön", "gul" };
            Game testGame = new Game();

            Console.WriteLine("Hur många spelare?: ");
            int antalSpelare = int.Parse(Console.ReadLine());
            for (int i = 1; i <= antalSpelare; i++)
            {
                var newPlayer = new Player();
                Console.WriteLine($"Skriv ditt namn spelare: {i}");
                newPlayer.PlayerName = Console.ReadLine();
                Console.WriteLine("Välj färg");
                for (int x = 0; x < colors.Count; x++)
                {
                    Console.WriteLine($"{x} , {colors[x]}");
                }
                for (int y = 0; y < 4; y++)
                {
                    var newToken = new Token();
                    newPlayer.Tokens.Add(newToken);
                }
                int colorChose = int.Parse(Console.ReadLine());
                newPlayer.PlayerColor = colors[colorChose];
                testGame.Players.Add(newPlayer);
                colors.RemoveAt(colorChose);
                Console.Clear();
            }

            var context = new MyContext();
            context.Add<Game>(testGame);
            context.SaveChanges();
            var testDatabas = context.Games.Include(g => g.Players).Where(g => g.Finished == false).FirstOrDefault();
        }

       
    }
}