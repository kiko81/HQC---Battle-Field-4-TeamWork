namespace BattleField.GameObjects.Handlers
{
    public class QuadBombHandler : BombTypeHandlerBase
    {
        public override void HandleBombType(int bombType, out int[,] result)
        {
            if (bombType == 4)
            {
                result = new QuadBomb().Explosion;
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