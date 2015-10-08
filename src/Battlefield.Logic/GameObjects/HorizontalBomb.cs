namespace Battlefield.Logic.GameObjects
{
    using Common;

    public class HorizontalBomb : Bomb
    {
        private readonly int[,] bomb = Constants.HorizontalBomb;

        protected override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
