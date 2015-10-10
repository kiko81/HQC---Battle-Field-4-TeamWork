namespace Battlefield.Logic.GameObjects.Bombs
{
    using System;

    public class NoBomb : Bomb
    {
        private static readonly Lazy<NoBomb> Lazy =
            new Lazy<NoBomb>(() => new NoBomb());

        private readonly int[,] bomb =
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 }
        };

        private NoBomb()
        {
        }

        public static NoBomb Instance
        {
            get { return Lazy.Value; }
        }

        public override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
