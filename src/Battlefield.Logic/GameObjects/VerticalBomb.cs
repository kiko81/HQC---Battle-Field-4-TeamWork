namespace BattleField.GameObjects
{
    using Common;

    public class VerticalBomb : Bomb
    {
        private readonly int[,] bomb = Constants.VerticalBomb;

        protected override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
