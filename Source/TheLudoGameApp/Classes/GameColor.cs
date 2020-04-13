using System;
using System.Collections.Generic;
using System.Text;
using TheLudoGameEngine;

namespace TheLudoGameApp.Classes
{
    public static class GameColor
    {
        public static void WriteLine(this Player player, string text)
        {
            WriteToConsole(player.PlayerColor, text);
        }

        public static void WriteLine(this Token token, string text)
        {
            WriteToConsole(token.TokenColor, text);
        }

        private static void WriteToConsole(string color, string text)
        {
            var currentColor = Console.ForegroundColor;

            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
            Console.WriteLine(text);
            Console.ForegroundColor = currentColor;
        }
    }
}