namespace BattleField.GameObjects
{
    using Common;

    public class XBomb : Bomb
    {
        private readonly int[,] bomb = Constants.XBomb;

        protected override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
