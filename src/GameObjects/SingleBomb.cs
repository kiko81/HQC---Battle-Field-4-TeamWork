namespace BattleField.GameObjects
{
    using Common;

    public class SingleBomb : Bomb
    {
        private readonly int[,] bomb = Constants.SingleBomb;

        protected override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
