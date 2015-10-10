namespace Battlefield.Logic.GameObjects.Bombs
{
    using System;

    public class XBomb : Bomb
    {
        private static readonly Lazy<XBomb> Lazy = 
            new Lazy<XBomb>(() => new XBomb());

        private readonly int[,] bomb =
        {
            { 1, 0, 0, 0, 1 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 1, 0, 0, 0, 1 }
        };

        private XBomb()
        {
        }

        public static XBomb Instance
        {
            get { return Lazy.Value; }
        }

        public override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
