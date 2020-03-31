using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class TokenMovement
    {
        public static int ThrowDie()
        {
            Random dieThrow = new Random();

            int result = dieThrow.Next(1, 7);

            return result;
        }

        public static int MoveToken(int tokenCurrentPosition, int dieResult)
        {
            int tokenNewPosition = tokenCurrentPosition;

            for (int i = 1; i <= dieResult; i++)
            {
                if (tokenNewPosition >= 45)
                {
                    for (int y = i; y <= dieResult; y++)
                    {
                        i++;
                        tokenNewPosition--;
                    }
                }
                else
                {
                    tokenNewPosition++;
                }
            }
            return tokenNewPosition;
        }
    }


}
