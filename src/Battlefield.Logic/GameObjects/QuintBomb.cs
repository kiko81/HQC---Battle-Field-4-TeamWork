namespace Battlefield.Logic.GameObjects
{
    public class QuintBomb : Bomb
    {
        private readonly int[,] bomb =
        {
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 }
        };

        protected override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
