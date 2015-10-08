namespace Battlefield.Logic.Common
{
    using System;

    public static class RandomUtils
    {
        private static Random rand = new Random();

        public static int GenerateRandomNumber(int start, int end)
        {
            return rand.Next(start, end);
        }
    }
}
