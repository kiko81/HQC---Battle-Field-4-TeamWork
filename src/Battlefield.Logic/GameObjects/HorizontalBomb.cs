namespace Battlefield.Logic.GameObjects
{
    public class HorizontalBomb : Bomb
    {
        private readonly int[,] bomb =
        {
            { 1, 0, 0, 0, 1 },
            { 1, 1, 0, 1, 1 },
            { 0, 1, 1, 1, 0 },
            { 1, 1, 0, 1, 1 },
            { 1, 0, 0, 0, 1 }
        };

        protected override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
