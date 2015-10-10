namespace Battlefield.Logic.GameObjects.Bombs
{
    using System;

    public class TripleBomb : Bomb
    {
        private static readonly Lazy<TripleBomb> Lazy =
            new Lazy<TripleBomb>(() => new TripleBomb());

        private readonly int[,] bomb =
        {
            { 0, 0, 1, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 1, 0, 0 }
        };

        private TripleBomb()
        {
        }

        public static TripleBomb Instance
        {
            get { return Lazy.Value; }
        }

        public override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
