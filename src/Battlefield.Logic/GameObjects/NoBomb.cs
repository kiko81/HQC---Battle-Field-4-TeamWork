namespace Battlefield.Logic.GameObjects
{
    using Battlefield.Logic.Common;

    public class NoBomb : Bomb
    {
        private readonly int[,] bomb = Constants.NoBomb;

        protected override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
