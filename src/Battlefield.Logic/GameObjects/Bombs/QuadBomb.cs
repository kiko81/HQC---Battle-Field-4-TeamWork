namespace Battlefield.Logic.GameObjects.Bombs
{
    using System;

    public class QuadBomb : Bomb
    {
        private static readonly Lazy<QuadBomb> Lazy =
            new Lazy<QuadBomb>(() => new QuadBomb());

        private readonly int[,] bomb =
        {
            { 0, 1, 1, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 0 }
        };

        private QuadBomb()
        {
        }

        public static QuadBomb Instance
        {
            get { return Lazy.Value; }
        }

        public override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
