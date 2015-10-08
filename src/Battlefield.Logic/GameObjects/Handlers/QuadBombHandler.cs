namespace Battlefield.Logic.GameObjects.Handlers
{
    public class QuadBombHandler : BombHandler
    {
        public override int[,] HandleBombType(int bombType)
        {
            if (bombType == 4)
            {
                return new QuadBomb().Explosion;
            }

            if (this.Successor != null)
            {
                return this.Successor.HandleBombType(bombType);
            }

            return new NoBomb().Explosion;
        }
    }
}