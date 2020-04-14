using System.Drawing;
using TheLudoGameEngine;

namespace TheLudoGameEngine
{
    public class Token
    {
        public int TokenID { get; set; }
        public Player Player { get; set; }
        public string TokenColor { get; set; }
        public int TokenNumber { get; set; }
        public int GameBoardPosition { get; set; }
        public int StepCounter { get; set; }
        public bool InNest { get; set; }
        public bool InGoal { get; set; }
        public bool InEndLap { get; set; }

        public void CountTokenSteps(Token currentToken, int dieResult)
        {
            int even = currentToken.StepCounter + dieResult;

            if (even <= 45)
            {
                currentToken.StepCounter += dieResult;
                if (currentToken.StepCounter >= 40)
                {
                    currentToken.TokenStartGameBoardPosition(currentToken);
                }
            }
            else
            {
                currentToken.StepCounter = 45 - (even - 45);
                currentToken.TokenStartGameBoardPosition(currentToken);
            }
        }

        public bool AtEndLap()
        {
            if (StepCounter > 40)
            {
                return InEndLap = true;
            }
            else
            {
                return InEndLap = false;
            }
        }

        public void CountTokenGameBordPosition(int dieResult)
        {
            if (InEndLap != true && StepCounter < 40)
            {
                int lap = GameBoardPosition + dieResult;
                if (lap <= 40)
                {
                    GameBoardPosition += dieResult;
                }
                else
                {
                    GameBoardPosition = lap - 40;
                }
            }
        }

        public bool TokenInGoal()
        {
            if (StepCounter == 45)
            {
                return InGoal = true;
            }
            else
            {
                return InGoal = false;
            }
        }

        public void TokenStartGameBoardPosition(Token setStart)
        {
            if (setStart.TokenColor == "Red")
            {
                setStart.GameBoardPosition = 40;
            }
            else if (setStart.TokenColor == "Blue")
            {
                setStart.GameBoardPosition = 10;
            }
            else if (setStart.TokenColor == "Green")
            {
                setStart.GameBoardPosition = 20;
            }
            else if (setStart.TokenColor == "Yellow")
            {
                setStart.GameBoardPosition = 30;
            }
        }
    }
}