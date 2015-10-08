namespace Battlefield.Logic.GameObjects.Handlers
{
    public class TripleBombHandler : BombHandler
    {
        public override void HandleBombType(int bombType, out int[,] result)
        {
            if (bombType == 3)
            {
                result = new TripleBomb().Explosion;
            }
            else if (this.Successor != null)
            {
                this.Successor.HandleBombType(bombType, out result);
            }
            else
            {
                result = new NoBomb().Explosion;
            }
        }
    }
}