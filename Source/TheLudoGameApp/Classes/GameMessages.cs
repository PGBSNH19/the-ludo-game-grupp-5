using System;
using System.Collections.Generic;
using TheLudoGameEngine;

namespace TheLudoGameApp.Classes
{
    internal class GameMessages
    {
        public static void PrintLoadGameList(List<Game> gamesToLoad)
        {
            for (int i = 0; i < gamesToLoad.Count; i++)
            {
                Console.WriteLine($"[{i}]: Name: {gamesToLoad[i].GameName}     Last saved: {gamesToLoad[i].LastSaved}");
            }
            Console.WriteLine("Please chose which game you want to load");
        }

        public static void PrintCurrentStatus(List<Player> players)
        {
            foreach (var player in players)
            {
                player.WriteLine($"{player.PlayerColor} {player.PlayerName}\n");
                foreach (var token in player.Tokens)
                {
                    if (token.InNest == true)
                    {
                        player.WriteLine($"{token.TokenColor} {token.TokenNumber}: In nest");
                    }
                    else if (token.InNest == false && token.InGoal == false && token.InEndLap == false)
                    {
                        player.WriteLine($"{token.TokenColor} {token.TokenNumber}: On space {token.GameBoardPosition} Steps: {token.StepsCounter}");
                    }
                    else if (token.InEndLap == true && token.InGoal == false)
                    {
                        player.WriteLine($"{token.TokenColor} {token.TokenNumber}: At goalline Steps: {token.StepsCounter}");
                    }
                    else
                    {
                        player.WriteLine($"{token.TokenColor} {token.TokenNumber}: In Goal");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void PrintDieResult(int die, Player player)
        {
            player.WriteLine($"Die result: {die}");
        }

        public static void PrintPlayerTurn(Player player)
        {
            player.WriteLine($"{player.PlayerName} turn");
            player.WriteLine($"Press any button to throw the die");
            Console.WriteLine("Press X to save and exit game");
        }

        public static void PrintKnockOut()
        {
            Console.WriteLine("Not yet implemented");
        }

        public static void PrintWinner(Player player)
        {
            Console.WriteLine($"The winner is {player.PlayerName}");
        }

        public static void PrintTokenOptions(List<Token> tokens, Player player)
        {
            player.WriteLine("Which token do you want to move?");
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