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

        public void MenuNewGame()
        {
            bool menu = true;
            while (menu)
            {
                Console.WriteLine("Please name your game: ");

                string gameName = Console.ReadLine();
                newGame.NameTheGame(gameName);

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

        public void MenuLoadGameFromDataBase()
        {
            var loadgames = engine.ShowPreviousGames();
            bool gameLoaded = false;
            GameMessages.PrintLoadGameList(loadgames);
            while (!gameLoaded)
            {
                string loadGameIndex = Console.ReadLine();
                try
                {
                    RunGame(loadgames[int.Parse(loadGameIndex)]);
                    gameLoaded = true;
                }
                catch
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
        }

        public void RunGame(Game game)
        {
            bool gameFinished = false;
            bool tokenChosed = false;
            while (!gameFinished)
            {
                
                Console.Clear();
                GameMessages.PrintCurrentStatus(game.Players);
                GameMessages.PrintPlayerTurn(game.Players[game.PlayerTurn]);
                string exitOrContinue = Console.ReadLine().ToLower();
                if (exitOrContinue != "x")
                {
                    var die = engine.ThrowDie();

                    GameMessages.PrintDieResult(die, game.Players[game.PlayerTurn]);

                    var movableTokens = engine.MovableTokens(game.Players[game.PlayerTurn], die);

                    if (movableTokens.Count > 0)
                    {
                        GameMessages.PrintTokenOptions(movableTokens, game.Players[game.PlayerTurn]);
                        tokenChosed = false;
                        while (!tokenChosed)
                        {
                            try
                            {
                                int movableTokensIndex = int.Parse(Console.ReadLine());
                                var tokenToMove = engine.ChooseToken(game.Players[game.PlayerTurn].Tokens, movableTokens[movableTokensIndex]);
                                engine.RunPlayerTurn(tokenToMove, die, game, game.Players[game.PlayerTurn]);
                                if (engine.tokenToKnockOut != null)
                                {
                                    Console.WriteLine($"{tokenToMove.TokenColor} {tokenToMove.TokenNumber} knocked out {engine.tokenToKnockOut.TokenColor} {engine.tokenToKnockOut.TokenNumber}");
                                    Console.WriteLine("Press any key to continue");
                                    Console.ReadKey();
                                }
                                tokenChosed = true;
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
                    engine.SaveGame(game);
                    gameFinished = game.Finished;
                }
                else
                {
                    engine.SaveGame(game);
                    MainMenu.Menu();
                }
            }
            Console.Clear();
            GameMessages.PrintCurrentStatus(game.Players);
            GameMessages.PrintWinner(game.GetVictoriousPlayer());
            Console.WriteLine("Press any key to retun to main menu");
            Console.ReadKey();
        }
    }
}