namespace Battlefield.Logic.GameObjects
{
    using Battlefield.Logic.Common;

    public class QuadBomb : Bomb
    {
        private readonly int[,] bomb = Constants.QuadBomb;

        protected override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
