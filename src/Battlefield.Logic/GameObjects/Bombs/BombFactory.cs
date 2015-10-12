namespace Battlefield.Logic.GameObjects.Bombs
{
    using System;

    /// <summary>
    /// Factory for creating bombs.
    /// </summary>
    public static class BombFactory
    {
        /// <summary>
        /// Method for creating bombs.
        /// </summary>
        /// <param name="bombType">Integer value of the bomb.</param>
        /// <returns>A bomb.</returns>
        public static Bomb CreateBomb(int bombType)
        {
            switch (bombType)
            {
                case 1:
                    return SingleBomb.Instance;
                case 2:
                    return DoubleBomb.Instance;
                case 3:
                    return TripleBomb.Instance;
                case 4:
                    return QuadBomb.Instance;
                case 5:
                    return QuintBomb.Instance;
                case 6:
                    return HorizontalBomb.Instance;
                case 7:
                    return VerticalBomb.Instance;
                case 8:
                    return XBomb.Instance;
                default:
                    throw new ArgumentException("no bomb there");
            }
        }
    }
}
