using System;
using System.Collections.Generic;
using System.Text;

namespace TheLudoGameEngine
{
    public class Engine : Game
    {
        public Player createNewPlayer = new Player();
        private Random dieThrow = new Random();
        private Token position = new Token();

        public int ThrowDie()
        {
            return dieThrow.Next(1, 7);
        }

        public void CreatePlayers(string namnSpelare, int color)
        {
            Players.Add(createNewPlayer);
            createNewPlayer.PlayerName = namnSpelare;
            createNewPlayer.PlayerColor = colors[color];
            colors.RemoveAt(color);
            for (int y = 0; y < 4; y++)
            {
                var createToken = new Token();
                createToken.InNest = true;
                createNewPlayer.Tokens.Add(createToken);
            }
        }

        public int CheckTurn()
        {
            PlayerTurn++;
            if (PlayerTurn > Players.Count - 1)
            {
                PlayerTurn = 0;
            }
            return PlayerTurn;
        }

        public void MoveToken(int dieResult)
        {
            for (int i = 1; i <= dieResult; i++)
            {
                if (position.GameBoardPosition >= 45)
                {
                    for (int y = i; y <= dieResult; y++)
                    {
                        i++;
                        position.GameBoardPosition--;
                    }
                }
                else
                {
                    position.GameBoardPosition++;
                }
            }
        }

        public void StartGame()
        {
        }
    }
}