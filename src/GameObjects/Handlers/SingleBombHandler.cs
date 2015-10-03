namespace BattleField.GameObjects.Handlers
{
    public class SingleBombHandler : BombTypeHandlerBase
    {
        public override void HandleBombType(int bombType, out int[,] result)
        {
            if (bombType == 1)
            {
                result = new SingleBomb().Explosion;
            }
            else if (this.successor != null)
            {
                successor.HandleBombType(bombType, out result);
            }
            else
            {
                result = new NoBomb().Explosion;
            }
        }
    }
}