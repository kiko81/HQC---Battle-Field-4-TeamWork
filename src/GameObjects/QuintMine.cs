namespace BattleField.GameObjects
{
    using Common;

    public class QuintMine : Mine
    {
        private readonly int[,] mine = Constants.QuintMine;

        protected override int[,] Explode()
        {
            return this.mine;
        }
    }
}
