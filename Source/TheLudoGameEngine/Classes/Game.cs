using System;
using System.Collections.Generic;
using System.Linq;

namespace TheLudoGameEngine

{
    public class Game
    {
        public int GameID { get; set; }
        public string GameName { get; set; }
        public DateTime LastSaved { get; set; }
        public bool Finished { get; set; }
        public int PlayerTurn { get; set; }
        public int Round { get; set; }
        public List<Player> Players { get; set; }

        public Game()
        {
            Players = new List<Player>();
            LastSaved = DateTime.Now;
            Round = 1;
        }

        public Player GetVictoriousPlayer()
        {
            return Players.FirstOrDefault(p => p.Winner == true);
        }

        public void NameTheGame(string name)
        {
            GameName = name;
        }

        public void CreatePlayer(string name, int color)
        {
            var newPlayer = new Player();
            newPlayer.PlayerName = name;
            newPlayer.PlayerColor = Enum.GetName(typeof(Colors), color);

            for (int i = 1; i < 5; i++)
            {
                var newToken = new Token();
                newToken.InNest = true;
                newToken.TokenNumber = i;
                newToken.TokenColor = Enum.GetName(typeof(Colors), color);
                newToken.TokensStartPostion(newToken);
                newPlayer.Tokens.Add(newToken);
            }

            Players.Add(newPlayer);
        }

        public enum Colors
        {
            Red,
            Blue,
            Green,
            Yellow
        }

        public int UpdateTurnAndRound()
        {
            PlayerTurn++;
            if (PlayerTurn > Players.Count - 1)
            {
                Round++;
                PlayerTurn = 0;
            }
            return PlayerTurn;
        }

        public bool CheckForWinner(Player player)
        {
            if (player.Tokens.Where(p => p.InGoal == true).Count() == 4)
            {
                player.Winner = true;
                return Finished = true;
            }
            return Finished = false;
        }
    }
}