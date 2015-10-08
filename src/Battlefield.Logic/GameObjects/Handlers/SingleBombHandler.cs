namespace Battlefield.Logic.GameObjects.Handlers
{
    public class SingleBombHandler : BombHandler
    {
        public override int[,] HandleBombType(int bombType)
        {
            if (bombType == 1)
            {
                return new SingleBomb().Explosion;
            }

            if (this.Successor != null)
            {
                return this.Successor.HandleBombType(bombType);
            }

            return new NoBomb().Explosion;
        }
    }
}