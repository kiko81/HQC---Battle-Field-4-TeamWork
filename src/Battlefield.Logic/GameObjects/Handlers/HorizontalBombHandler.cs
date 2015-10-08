namespace Battlefield.Logic.GameObjects.Handlers
{
    public class HorizontalBombHandler : BombHandler
    {
        public override int[,] HandleBombType(int bombType)
        {
            if (bombType == 8)
            {
                return new HorizontalBomb().Explosion;
            }

            if (this.Successor != null)
            {
                return this.Successor.HandleBombType(bombType);
            }

            return new NoBomb().Explosion;
        }
    }
}
