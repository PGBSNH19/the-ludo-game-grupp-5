using System;
using System.Collections.Generic;
using System.Threading;
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
                        Console.WriteLine("Invalid input, try again");
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
                Console.WriteLine(game.PlayerTurn);
                Console.ReadKey();

                var die = engine.ThrowDie();

                GameMessages.PrintDieResult(die);

                var movableTokens = engine.TokensToMove(game.Players[game.PlayerTurn], die);

                if (movableTokens.Count > 0)
                {
                    GameMessages.PrintTokenOptions(movableTokens);

                    while (!gameFinished)
                    {
                        try
                        {
                            int movableTokensIndex = int.Parse(Console.ReadLine());
                            var tokenToMove = engine.ChooseToken(game.Players[game.PlayerTurn].Tokens, movableTokens[movableTokensIndex]);
                            engine.RunMovementAction(tokenToMove, die, game, game.Players[game.PlayerTurn]);
                            if (engine.tokenToKnockOut != null)
                            {
                                Console.WriteLine($"{tokenToMove.TokenColor} {tokenToMove.TokenNumber} knocked out {engine.tokenToKnockOut.TokenColor} {engine.tokenToKnockOut.TokenNumber}");

                                //Thread.Sleep(5000);
                                Console.ReadKey();
                            }
                            gameFinished = true;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid token, try again");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You need to throw 1 or 6 to leave the nest");
                    Console.ReadKey();
                    engine.RunGameUpdate(game);
                }

                gameFinished = game.Finished;
            }
            Console.Clear();
            GameMessages.PrintCurrentStatus(game.Players);
            GameMessages.PrintWinner(game.GetVictoriousPlayer());
            Console.ReadKey();
        }
    }
}