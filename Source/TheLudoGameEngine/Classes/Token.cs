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
        public int StepsCounter { get; set; }
        public bool InNest { get; set; }
        public bool InGoal { get; set; }
        public bool InEndLap { get; set; }

        public void CountTokenSteps(Token currentToken, int dieResult)
        {
            int even = currentToken.StepsCounter + dieResult;

            if (even <= 45)
            {
                currentToken.StepsCounter += dieResult;
                if (currentToken.StepsCounter >= 40)
                {
                    currentToken.TokensStartPostion(currentToken);
                }
            }
            else
            {
                currentToken.StepsCounter = 45 - (even - 45);
                currentToken.TokensStartPostion(currentToken);
            }
        }

        public bool AtEndLap()
        {
            if (StepsCounter > 40)
            {
                return InEndLap = true;
            }
            else
            {
                return InEndLap = false;
            }
        }

        public void CountGameBordPosition(int dieResult)
        {
            if (InEndLap != true && StepsCounter < 40)
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
            if (StepsCounter == 45)
            {
                return InGoal = true;
            }
            else
            {
                return InGoal = false;
            }
        }

        public void TokensStartPostion(Token setEnd)
        {
            if (setEnd.TokenColor == "Red")
            {
                setEnd.GameBoardPosition = 40;
            }
            else if (setEnd.TokenColor == "Blue")
            {
                setEnd.GameBoardPosition = 10;
            }
            else if (setEnd.TokenColor == "Green")
            {
                setEnd.GameBoardPosition = 20;
            }
            else if (setEnd.TokenColor == "Yellow")
            {
                setEnd.GameBoardPosition = 30;
            }
        }
    }
}