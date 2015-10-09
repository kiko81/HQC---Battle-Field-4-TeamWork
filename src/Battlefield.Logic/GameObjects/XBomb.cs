namespace Battlefield.Logic.GameObjects
{
    using Battlefield.Logic.Common;

    public class XBomb : Bomb
    {
        private readonly int[,] bomb = Constants.XBomb;

        protected override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
