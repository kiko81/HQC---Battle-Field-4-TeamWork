namespace BattleField.GameObjects
{
    public class SingleMine : Mine
    {
        private readonly int[,] mine =
        {
            {0, 0, 0, 0, 0},
            {0, 1, 0, 1, 0},
            {0, 0, 1, 0, 0},
            {0, 1, 0, 1, 0},
            {0, 0, 0, 0, 0}
        };
        protected override int[,] Explode()
        {
            return this.mine;
        }
    }
}
