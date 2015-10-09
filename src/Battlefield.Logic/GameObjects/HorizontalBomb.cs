namespace Battlefield.Logic.GameObjects
{
    using Battlefield.Logic.Common;

    public class HorizontalBomb : Bomb
    {
        private readonly int[,] bomb = Constants.HorizontalBomb;

        protected override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
