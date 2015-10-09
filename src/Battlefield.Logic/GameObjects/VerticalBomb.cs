namespace Battlefield.Logic.GameObjects
{
    using Battlefield.Logic.Common;

    public class VerticalBomb : Bomb
    {
        private readonly int[,] bomb = Constants.VerticalBomb;

        protected override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
