namespace Battlefield.Logic.GameObjects.Bombs
{
    using System;

    public class HorizontalBomb : Bomb
    {
        private static readonly Lazy<HorizontalBomb> Lazy =
            new Lazy<HorizontalBomb>(() => new HorizontalBomb());

        private readonly int[,] bomb =
        {
            { 1, 0, 0, 0, 1 },
            { 1, 1, 0, 1, 1 },
            { 0, 1, 1, 1, 0 },
            { 1, 1, 0, 1, 1 },
            { 1, 0, 0, 0, 1 }
        };

        private HorizontalBomb()
        {
        }

        public static HorizontalBomb Instance
        {
            get { return Lazy.Value; }
        }

        public override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
