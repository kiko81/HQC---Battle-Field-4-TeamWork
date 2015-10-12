namespace Battlefield.Logic.GameObjects
{
    using Battlefield.Logic.GameObjects.Bombs;

    public class ExplosionStrategy
    {
        private Bomb bomb;

        public ExplosionStrategy(int bombType)
        {
            this.Bomb = BombFactory.CreateBomb(bombType);
        }

        public Bomb Bomb
        {
            get { return this.bomb; }
            set { this.bomb = value; }
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
