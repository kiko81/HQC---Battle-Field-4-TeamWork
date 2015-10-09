namespace Battlefield.Logic.GameObjects
{
    public class TripleBomb : Bomb
    {
        private readonly int[,] bomb =
        {
            { 0, 0, 1, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 1, 0, 0 }
        };

        protected override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
