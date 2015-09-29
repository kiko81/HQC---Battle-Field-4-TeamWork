namespace BattleField.GameObjects
{
    using Common;

    public class TripleBomb : Bomb
    {
        private readonly int[,] bomb = Constants.TripleBomb;

        protected override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
