namespace Battlefield.Logic.GameObjects
{
    public abstract class Bomb
    {
        private int[,] bomb;

        public int[,] Explosion
        {
            get { return this.Explode(); }
        }

        protected abstract int[,] Explode();
    }
}
