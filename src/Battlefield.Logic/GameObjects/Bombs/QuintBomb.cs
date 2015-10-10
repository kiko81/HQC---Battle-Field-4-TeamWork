namespace Battlefield.Logic.GameObjects.Bombs
{
    using System;

    public class QuintBomb : Bomb
    {
        private static readonly Lazy<QuintBomb> Lazy =
            new Lazy<QuintBomb>(() => new QuintBomb());

        private readonly int[,] bomb =
        {
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 }
        };

        private QuintBomb()
        {
        }

        public static QuintBomb Instance
        {
            get { return Lazy.Value; }
        }

        public override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
