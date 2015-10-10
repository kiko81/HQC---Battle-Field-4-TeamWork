namespace Battlefield.Logic.GameObjects.Bombs
{
    using System;

    public class VerticalBomb : Bomb
    {
        private static readonly Lazy<VerticalBomb> Lazy = 
            new Lazy<VerticalBomb>(() => new VerticalBomb());

        private readonly int[,] bomb =
        {
            { 1, 1, 0, 1, 1 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 1, 1, 0, 1, 1 }
        };

        private VerticalBomb()
        {
        }

        public static VerticalBomb Instance
        {
            get { return Lazy.Value; }
        }

        public override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
