using System;
using System.Collections.Generic;
using System.Linq;
using TheLudoGameEngine;

namespace TheLudoGameApp.Classes
{
    internal class GameMessages
    {
        public static void PrintPreviousGameResult(List<Game> finishedGames)
        {
            foreach (var game in finishedGames)
            {
                var victoriousPlayer = finishedGames.SelectMany(g => game.Players).Distinct().FirstOrDefault(p => p.Winner == true);
                Console.WriteLine($"Game: {game.GameName}   Won by: {victoriousPlayer.PlayerName}  Within: {game.Round} rounds   Date: {game.LastSaved}");
            }
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
        }
        public static void PrintLoadGameList(List<Game> gamesToLoad)
        {
            for (int i = 0; i < gamesToLoad.Count; i++)
            {
                Console.WriteLine($"[{i}]: Name: {gamesToLoad[i].GameName}     Last saved: {gamesToLoad[i].LastSaved}");
            }
            Console.WriteLine("Please chose which game you want to load");
        }

        public static void PrintAllPlayerAndTokensValue(List<Player> players)
        {
            foreach (var player in players)
            {
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), player.PlayerColor);
                Console.WriteLine($"{player.PlayerColor} {player.PlayerName}\n");
                foreach (var token in player.Tokens)
                {
                    if (token.InNest == true)
                    {
                        Console.WriteLine($"{token.TokenColor} {token.TokenNumber}: In nest");
                    }
                    else if (token.InNest == false && token.InGoal == false && token.InEndLap == false)
                    {
                        Console.WriteLine($"{token.TokenColor} {token.TokenNumber}: On space {token.GameBoardPosition} Steps: {token.StepCounter}");
                    }
                    else if (token.InEndLap == true && token.InGoal == false)
                    {
                        Console.WriteLine($"{token.TokenColor} {token.TokenNumber}: At goalline Steps: {token.StepCounter}");
                    }
                    else
                    {
                        Console.WriteLine($"{token.TokenColor} {token.TokenNumber}: In Goal");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void PrintDieResult(int die)
        {
            Console.WriteLine($"Die result: {die}");
        }

        public static void PrintPlayerTurn(Player player)
        {
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), player.PlayerColor);
            Console.WriteLine($"{player.PlayerName} turn");
            Console.ResetColor();
            Console.WriteLine($"Press any button to throw the die");
            Console.WriteLine("Press X to save and exit game");
        }

        public static void PrintWinner(Player player)
        {
            Console.WriteLine($"The winner is {player.PlayerName}");
        }

        public static void PrintMovableTokens(List<Token> tokens)
        {
            Console.WriteLine("Which token do you want to move?");
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].InNest == true)
                {
                    Console.WriteLine($"[{i}] Move token {tokens[i].TokenColor} {tokens[i].TokenNumber} out from nest");
                }
                else
                {
                    Console.WriteLine($"[{i}] Move token {tokens[i].TokenColor} {tokens[i].TokenNumber}");
                }
            }
        }
    }
}