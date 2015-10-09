namespace Battlefield.Logic.GameObjects
{
    using Battlefield.Logic.Common;

    public class TripleBomb : Bomb
    {
        private readonly int[,] bomb = Constants.TripleBomb;

        protected override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
