namespace Battlefield.Logic.Common
{
    using System;

    /// <summary>
    /// Random utilities class.
    /// </summary>
    public static class RandomUtils
    {
        private static readonly Random Rand = new Random();

        /// <summary>
        /// Method returning random integer value between two integers.
        /// </summary>
        /// <param name="start">Integer - start value.</param>
        /// <param name="end">Integer - end value.</param>
        /// <returns>Random integer.</returns>
        public static int GenerateRandomNumber(int start, int end)
        {
            return Rand.Next(start, end + 1);
        }
    }
}
