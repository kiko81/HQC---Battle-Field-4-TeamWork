namespace Battlefield.Logic.GameObjects
{
    public class QuadBomb : Bomb
    {
        private readonly int[,] bomb =
        {
            { 0, 1, 1, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 0 }
        };

        protected override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
