using System;
using System.Collections.Generic;
using TheLudoGameEngine;

namespace TheLudoGameApp.Classes
{
    internal class GameMenu
    {
        public Game newGame = new Game();
        public Engine engine = new Engine();
        private List<string> playerNames = new List<string>();

        public void MenuNewGame()
        {
            bool menu = true;
            while (menu)
            {
                Console.WriteLine("How many players min 2 and max 4? ");
                string amountOfPlayers = Console.ReadLine();
                if (int.TryParse(amountOfPlayers, out int number))
                {
                    if (number >= 2 && number <= 4)
                    {
                        for (int i = 0; i < number; i++)
                        {
                            Console.WriteLine($"Player {i + 1} name: ");
                            newGame.CreatePlayer(Console.ReadLine(), i);
                        }
                        menu = false;
                    }
                    else
                    {
                        Console.WriteLine("You have entred wrog value");
                    }
                }
                else
                {
                    Console.WriteLine($"{amountOfPlayers} is not a number");
                }
            }

            RunGame(newGame);
        }

        public void MenuLoadGame()
        {
            var loadGame = engine.ShowPreviousGames();
            GameMessages.PrintLoadGameList(loadGame);
            RunGame(loadGame[int.Parse(Console.ReadLine())]);
        }

        public void RunGame(Game game)
        {
            bool gameFinished = false;
            while (!gameFinished)
            {
                Console.Clear();
                GameMessages.PrintCurrentStatus(game.Players);
                GameMessages.PrintPlayerTurn(game.Players[game.PlayerTurn]);
                Console.ReadKey();

                var die = engine.ThrowDie();

                GameMessages.PrintDieResult(die);

                var moveableTokens = engine.TokensToMove(game.Players[game.PlayerTurn], die);

                if (moveableTokens.Count > 0)
                {
                    GameMessages.PrintTokenOptions(moveableTokens);
                    
                    while (!gameFinished)
                    {
                        try 
                        {
                            int val = int.Parse(Console.ReadLine());
                            var testToken = engine.ChooseToken(game.Players[game.PlayerTurn].Tokens, moveableTokens[val]);
                            engine.RunMovementAction(testToken, die, game, game.Players[game.PlayerTurn]);
                            gameFinished = true;
                        }
                        catch
                        {
                            Console.WriteLine("Try again");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You need to throw 1 or 6 to leave the nest");
                    Console.ReadKey();
                }
                if(die != 6)
                {
                    engine.RunGameUpdate(game, game.Players[game.PlayerTurn]);
                }
                
                gameFinished = game.Finished;
            }
            Console.Clear();
            GameMessages.PrintCurrentStatus(game.Players);
            GameMessages.PrintWinner(game.Players[game.PlayerTurn]);
            Console.ReadKey();
        }
    }
}