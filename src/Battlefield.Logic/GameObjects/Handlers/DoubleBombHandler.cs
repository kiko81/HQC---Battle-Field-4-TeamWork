namespace Battlefield.Logic.GameObjects.Handlers
{
    public class DoubleBombHandler : BombHandler
    {
        public override int[,] HandleBombType(int bombType)
        {
            if (bombType == 2)
            {
                return new DoubleBomb().Explosion;
            }

            if (this.Successor != null)
            {
                return this.Successor.HandleBombType(bombType);
            }

            return new NoBomb().Explosion;
        }
    }
}