namespace Battlefield.Logic.Common
{
    using System;

    public static class RandomUtils
    {
        private static readonly Random Rand = new Random();

        public static int GenerateRandomNumber(int start, int end)
        {
            return Rand.Next(start, end);
        }
    }
}
