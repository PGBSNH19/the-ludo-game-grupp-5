using System;
using System.Collections.Generic;
using System.Text;
using TheLudoGameEngine;

namespace TheLudoGameApp.Classes
{
    class GameMenu
    {
        public Game newGame = new Game();
        public Engine engine = new Engine();

        public void NewGameMenu()
        {
            Console.WriteLine("How many players? ");

            int amountOfPlayers = int.Parse(Console.ReadLine());

            for (int i = 0; i < amountOfPlayers; i++)
            {
                Console.WriteLine($"Player {i + 1} name: ");
                newGame.CreatePlayers(Console.ReadLine(), i);
            }

            InGame(newGame);
        }

        public void LoadGameMenu()
        {
            var loadGame = engine.LoadPreviousGames();
            GameMessages.PrintLoadGameList(loadGame);
            InGame(loadGame[int.Parse(Console.ReadLine())]);
        }

        /*For the moment a gameflow prototype*/
        public void InGame(Game game)
        {
            bool loop = false;
            int testVal = 0;
            while (!loop)
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
                    testVal = int.Parse(Console.ReadLine());
                    var testToken = engine.ChooseToken(game.Players[game.PlayerTurn].Tokens, moveableTokens[testVal]);
                    engine.RunMovementAction(testToken, die);
                }
                else
                {
                    Console.WriteLine("You dont have any movable tokens, press any key for next player");
                    Console.ReadKey();
                }

                engine.RunGameUpdate(game, game.Players[game.PlayerTurn]);
                engine.SaveGame(game);
                loop = game.Finished;
            }
            Console.Clear();
            GameMessages.PrintCurrentStatus(game.Players);
            GameMessages.PrintWinner(game.Players[game.PlayerTurn]);
        }
    }
}
