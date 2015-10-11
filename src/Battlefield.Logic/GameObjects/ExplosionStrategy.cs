namespace Battlefield.Logic.GameObjects
{
    using Battlefield.Logic.GameObjects.Bombs;

    public class ExplosionStrategy
    {
        private readonly Bomb bomb;

        public ExplosionStrategy(int bombType)
        {
            this.bomb = BombFactory.CreateBomb(bombType);
        }

        public int[,] GetExplosion()
        {
            return this.bomb.Explode();
        }

        public int[,] GetInvertedExplosion()
        {
            var invertedBomb = new Invertable(this.bomb);

            return invertedBomb.InvertExplosion();
        }
    }
}
