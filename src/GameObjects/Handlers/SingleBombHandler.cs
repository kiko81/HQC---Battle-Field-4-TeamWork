namespace BattleField.GameObjects.Handlers
{
    public class SingleBombHandler : BombHandler
    {
        public override void HandleBombType(int bombType, out int[,] result)
        {
            if (bombType == 1)
            {
                result = new SingleBomb().Explosion;
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