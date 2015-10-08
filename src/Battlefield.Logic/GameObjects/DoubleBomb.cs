namespace BattleField.GameObjects
{
    using Common;

    public class DoubleBomb : Bomb
    {
        private readonly int[,] bomb = Constants.DoubleBomb;

        protected override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
