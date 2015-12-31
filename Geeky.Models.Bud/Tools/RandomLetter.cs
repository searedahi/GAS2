using System;

namespace Geeky.Models.Bud.Tools
{
    public static class RandomLetter
    {
        static Random _random = new Random();
        public static char GetLetter()
        {
            // This method returns a random lowercase letter.
            // ... Between 'a' and 'z' inclusize.
            int num = _random.Next(0, 26); // Zero to 25
            char let = (char)('a' + num);
            return let;
        }
    }
}
