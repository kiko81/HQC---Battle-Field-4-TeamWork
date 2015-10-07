namespace BattleField.GameObjects.Handlers
{
    public class XBombHandler : BombHandler
    {
        public override void HandleBombType(int bombType, out int[,] result)
        {
            if (bombType == 6)
            {
                result = new XBomb().Explosion;
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
