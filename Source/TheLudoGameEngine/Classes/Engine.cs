using System;
using System.Collections.Generic;
using System.Text;

namespace TheLudoGameEngine
{
    public class Engine : Game
    {
        public void RunMovementAction(Game game, int die)
        {
            game.Players[game.PlayerTurn].Tokens[0].InNest = false;
            game.Players[game.PlayerTurn].Tokens[0].MoveToken(die);
            if (game.Players[game.PlayerTurn].Tokens[0].HasFinished() != true)
            {
                game.CheckTurn();
            }
            game.CheckWinner(game.Players[game.PlayerTurn]);

        }

        public void RunGameUpdate(Game game)
        {

        }
    }
}