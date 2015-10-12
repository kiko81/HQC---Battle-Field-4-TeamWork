namespace Battlefield.Logic.GameObjects.Bombs
{
    /// <summary>
    /// Abstract decorator implemented by bomb decorators.
    /// </summary>
    public abstract class BombDecorator : Bomb
    {
        private Bomb bomb;

        public BombDecorator(Bomb bomb)
        {
            this.bomb = bomb;
        }

        /// <summary>
        /// Override method of the original bomb explosion.
        /// </summary>
        /// <returns>Explosion pattern.</returns>
        public override int[,] Explode()
        {
            return this.bomb.Explode();
        }
    }
}
