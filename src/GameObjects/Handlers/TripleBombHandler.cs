namespace BattleField.GameObjects.Handlers
{
    public class TripleBombHandler : BombTypeHandlerBase
    {
        public override void HandleBombType(int bombType, out int[,] result)
        {
            if (bombType == 3)
            {
                result = new TripleBomb().Explosion;
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