namespace BattleField.GameObjects
{
    using Common;

    public class DoubleMine : Mine
    {
        private readonly int[,] mine = Constants.DoubleMine;

        protected override int[,] Explode()
        {
            return this.mine;
        }
    }
}
