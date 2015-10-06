namespace BattleField.GameObjects.Handlers
{
    public class HorizontalBombHandler : BombTypeHandlerBase
    {
        public override void HandleBombType(int bombType, out int[,] result)
        {
            if (bombType == 8)
            {
                result = new HorizontalBomb().Explosion;
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
