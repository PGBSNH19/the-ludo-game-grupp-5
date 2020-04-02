using System;

namespace TheLudoGameEngine
{
    public static class Die
    {
        public static int ThrowDie()
        {
            Random dieThrow = new Random();
            return dieThrow.Next(1, 7);
        }
    }
}