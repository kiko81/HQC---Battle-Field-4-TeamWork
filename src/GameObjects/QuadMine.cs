namespace BattleField.GameObjects
{
    using Common;

    public class QuadMine : Mine
    {
        private readonly int[,] mine = Constants.QuadMine;

        protected override int[,] Explode()
        {
            return this.mine;
        }
    }
}
