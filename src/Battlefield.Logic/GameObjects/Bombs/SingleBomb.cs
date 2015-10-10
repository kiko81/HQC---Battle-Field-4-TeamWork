namespace Battlefield.Logic.GameObjects.Bombs
{
    using System;

    public class SingleBomb : Bomb
    {
        private static readonly Lazy<SingleBomb> Lazy =
            new Lazy<SingleBomb>(() => new SingleBomb());

        private readonly int[,] bomb =
        {
            { 0, 0, 0, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 0, 0, 0 }
        };

        private SingleBomb()
        {
        }

        public static SingleBomb Instance
        {
            get { return Lazy.Value; }
        }

        public override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
