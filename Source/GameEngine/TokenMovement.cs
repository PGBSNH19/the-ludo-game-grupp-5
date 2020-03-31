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
    }
}
