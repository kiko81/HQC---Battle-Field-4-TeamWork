namespace BattleField.GameObjects
{
    public abstract class Bomb
    {
        public int[,] Explosion
        {
            get
            {
                return this.Explode();
            }
        }

        protected abstract int[,] Explode();
    }
}
