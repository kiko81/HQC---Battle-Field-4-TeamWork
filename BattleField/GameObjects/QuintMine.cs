namespace BattleField.GameObjects
{
    public class QuintMine : Mine
    {
        private readonly int[,] mine =
        {
            {1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1}
        };
        protected override int[,] Explode()
        {
            return this.mine;
        }
    }
}
