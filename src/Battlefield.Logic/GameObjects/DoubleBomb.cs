namespace Battlefield.Logic.GameObjects
{
    using Battlefield.Logic.Common;

    public class DoubleBomb : Bomb
    {
        private readonly int[,] bomb = Constants.DoubleBomb;

        protected override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
