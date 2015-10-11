namespace Battlefield.Logic.GameObjects.Bombs
{
    public class Invertable : BombDecorator
    {
        public Invertable(Bomb bomb) : base(bomb)
        {
        }

        public int[,] InvertExplosion()
        {
            var explosion = this.Explode();
            var size = explosion.GetLength(0);

            for (var row = 0; row < size; row++)
            {
                for (var col = 0; col < size; col++)
                {
                    explosion[row, col] = explosion[row, col] == 0 ? 1 : 0;
                }
            }

            return explosion;
        }
    }
}
