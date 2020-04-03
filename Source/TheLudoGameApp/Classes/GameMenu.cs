using System;
using System.Collections.Generic;
using System.Text;
using TheLudoGameEngine;

namespace TheLudoGameApp.Classes
{
    class GameMenu
    {
        public void NewGameMenu()
        {
            Game newGame = new Game();
            List<string> playerNames = new List<string>();
            Console.WriteLine("How many players? ");

            int amountOfPlayers = int.Parse(Console.ReadLine());

            for (int i = 0; i < amountOfPlayers; i++)
            {
                Console.WriteLine($"Player {i + 1} name: ");
                newGame.CreatePlayers(Console.ReadLine(), i);
            }


            InGame(newGame);
        }

        public  void InGame(Game game)
        {

            bool loop = false;
            while (!loop)
            {
                Console.Clear();
                GameMessages.PrintCurrentStatus(game.Players);
                GameMessages.PrintPlayerTurn(game.Players[game.PlayerTurn]);
                Console.ReadKey();
                
                var die = Die.ThrowDie();

                GameMessages.PrintDieResult(die);
                
                var moveableTokens = game.TokensToMove(game.Players[game.PlayerTurn], die);
                
                if (moveableTokens.Count > 0)
                {
                    GameMessages.PrintTokenOptions(moveableTokens);
                    Console.ReadKey();
                    game.RunMovement(game, die);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("You need to throw 1 or 6 to leave the nest");
                    Console.ReadKey();
                    game.CheckTurn();
                }

                loop = game.Finished;
            }
            Console.Clear();
            GameMessages.PrintCurrentStatus(game.Players);
            GameMessages.PrintWinner(game.Players[game.PlayerTurn]);
        }
    }
}
