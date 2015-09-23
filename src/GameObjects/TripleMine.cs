namespace BattleField.GameObjects
{
    using Common;

    public class TripleMine : Mine
    {
        private readonly int[,] mine = Constants.TripleMine;

        protected override int[,] Explode()
        {
            return this.mine;
        }
    }
}
