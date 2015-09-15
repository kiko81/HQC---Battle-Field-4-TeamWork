namespace BattleField.GameObjects
{
    public class QuadMine : Mine
    {
        private readonly int[,] mine =
        {
            {0, 1, 1, 1, 0},
            {1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1},
            {0, 1, 1, 1, 0}
        };
        protected override int[,] Explode()
        {
            return this.mine;
        }
    }
}
