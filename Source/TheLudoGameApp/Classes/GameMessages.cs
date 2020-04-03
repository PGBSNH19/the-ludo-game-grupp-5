using System;
using System.Collections.Generic;
using System.Text;
using TheLudoGameEngine;

namespace TheLudoGameApp.Classes
{
    class GameMessages
    {
        public static void PrintCurrentStatus(List<Player> players)
        {
            foreach (var player in players)
            {
                Console.WriteLine($"{player.PlayerColor} {player.PlayerName}");
                foreach (var token in player.Tokens)
                {
                    Console.WriteLine(token.GameBoardPosition);
                }
                Console.WriteLine();
            }

        }

        public static void PrintPlayerTurn(Player player)
        {
            Console.WriteLine($"{player.PlayerName} turn");
        }

        public static void PrintWinner(Player player)
        {
            Console.WriteLine($"The winner is {player.PlayerName}");
            Console.WriteLine($"Press any button to throw the die");
        }
    }
}
