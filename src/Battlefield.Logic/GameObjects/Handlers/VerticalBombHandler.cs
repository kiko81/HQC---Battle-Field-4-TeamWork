namespace Battlefield.Logic.GameObjects.Handlers
{
    public class VerticalBombHandler : BombHandler
    {
        public override int[,] HandleBombType(int bombType)
        {
            if (bombType == 7)
            {
                return new VerticalBomb().Explosion;
            }

            if (this.Successor != null)
            {
                return this.Successor.HandleBombType(bombType);
            }

            return new NoBomb().Explosion;
        }
    }
}
