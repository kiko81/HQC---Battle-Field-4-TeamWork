namespace Battlefield.Logic.GameObjects
{
    using Battlefield.Logic.Common;

    public class QuintBomb : Bomb
    {
        private readonly int[,] bomb = Constants.QuintBomb;

        protected override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
