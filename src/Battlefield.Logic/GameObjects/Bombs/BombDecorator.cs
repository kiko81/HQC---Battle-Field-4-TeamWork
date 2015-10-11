namespace Battlefield.Logic.GameObjects.Bombs
{
    public abstract class BombDecorator : Bomb
    {
        private Bomb bomb;

        public BombDecorator(Bomb bomb)
        {
            this.bomb = bomb;
        }

        public override int[,] Explode()
        {
            return this.bomb.Explode();
        }
    }
}
