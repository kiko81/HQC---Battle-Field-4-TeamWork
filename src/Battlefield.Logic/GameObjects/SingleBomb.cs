namespace Battlefield.Logic.GameObjects
{
    using Battlefield.Logic.Common;

    public class SingleBomb : Bomb
    {
        private readonly int[,] bomb = Constants.SingleBomb;

        protected override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
