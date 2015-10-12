namespace Battlefield.Logic.Common
{
    /// <summary>
    /// A common validator class.
    /// </summary>
    public static class Validators
    {
        /// <summary>
        /// Method validating if a given value is in range from 0 to given value.
        /// </summary>
        /// <param name="value">Integer to check.</param>
        /// <param name="size">Integer - border value.</param>
        /// <returns>Boolean value.</returns>
        public static bool IsInBounds(int value, int size)
        {
            return 0 <= value && value < size;
        }
    }
}
