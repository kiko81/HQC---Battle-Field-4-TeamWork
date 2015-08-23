namespace BattleField.GameObjects
{
    public abstract class Mine
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
