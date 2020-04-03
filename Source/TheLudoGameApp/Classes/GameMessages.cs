﻿using System;
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
                    if(token.InNest == true)
                    {
                        Console.WriteLine($"{token.TokenColor} {token.TokenNumber}: In nest");
                    }
                    else if(token.InNest == false && token.InGoal == false)
                    {
                        Console.WriteLine($"{token.TokenColor} {token.TokenNumber}: On space {token.GameBoardPosition}");
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
            Console.WriteLine($"{player.PlayerName} turn");
        }

        public static void PrintWinner(Player player)
        {
            Console.WriteLine($"The winner is {player.PlayerName}");
            Console.WriteLine($"Press any button to throw the die");
        }

        public static void PrintTokenOptions(List<Token> tokens)
        {
            int count = 0;
            Console.WriteLine("Which token do you want to move?");
            for(int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].InNest == true)
                {
                    Console.WriteLine($"[{count}] Move token {tokens[i].TokenColor} {tokens[i].TokenNumber} out from nest");
                }
                else
                {
                    Console.WriteLine($"[{count}] Move token {tokens[i].TokenColor} {tokens[i].TokenNumber} out from nest");
                }
                
            }
            
        }
    }
}
