namespace Battlefield.Logic.GameObjects
{
    public class NoBomb : Bomb
    {
        private readonly int[,] bomb =
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 }
        };

        protected override int[,] Explode()
        {
            return this.bomb;
        }
    }
}
