namespace Battlefield.Logic.GameObjects.Bombs
{
    using System;

    /// <summary>
    /// Double bomb class.
    /// </summary>
    public class DoubleBomb : Bomb
    {
        private static readonly Lazy<DoubleBomb> Lazy =
            new Lazy<DoubleBomb>(() => new DoubleBomb());

        private readonly int[,] bomb =
        {
            { 0, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 0 }
        };

        private DoubleBomb()
        {
        }

        /// <summary>
        /// Method instantiating bomb
        /// </summary>
        public static DoubleBomb Instance
        {
            get { return Lazy.Value; }
        }

        /// <summary>
        /// Explosion method.
        /// </summary>
        /// <returns>The explosion pattern.</returns>
        public override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
