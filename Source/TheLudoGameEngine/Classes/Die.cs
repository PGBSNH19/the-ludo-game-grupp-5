using System;

namespace TheLudoGameEngine
{
    public class Die
    {
        public int result { get; set; }

        public static int ThrowDie()
        {
            Random dieThrow = new Random();
            return dieThrow.Next(1, 7);
        }
    }
}