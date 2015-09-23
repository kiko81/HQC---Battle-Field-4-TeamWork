namespace BattleField.GameObjects
{
    using Common;

    public class SingleMine : Mine
    {
        private readonly int[,] mine = Constants.SingleMine;

        protected override int[,] Explode()
        {
            return this.mine;
        }
    }
}
