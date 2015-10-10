namespace Battlefield.Logic.GameObjects
{
    using Battlefield.Logic.GameObjects.Bombs;

    public class ExplosionStrategy
    {
        private Bomb bomb;

        public ExplosionStrategy(int bombType)
        {
            this.bomb = BombFactory.CreateBomb(bombType);
        }

        public int[,] GetExplosion()
        {
            return this.bomb.Explode();
        }
    }
}
