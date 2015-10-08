namespace Battlefield.Logic.GameObjects.Handlers
{
    public class QuintBombHandler : BombHandler
    {
        public override void HandleBombType(int bombType, out int[,] result)
        {
            if (bombType == 5)
            {
                result = new QuintBomb().Explosion;
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