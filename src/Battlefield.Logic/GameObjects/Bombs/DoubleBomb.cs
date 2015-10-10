namespace Battlefield.Logic.GameObjects.Bombs
{
    using System;

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

        public static DoubleBomb Instance
        {
            get { return Lazy.Value; }
        }

        public override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
