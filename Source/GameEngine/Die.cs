﻿using System;

namespace GameEngine
{
    public class Die
    {
        public static int ThrowDie()
        {
            Random dieThrow = new Random();

            int result = dieThrow.Next(1, 7);

            return result;
        }



    }
}
