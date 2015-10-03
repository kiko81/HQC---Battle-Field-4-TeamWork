namespace BattleField.GameObjects.Handlers
{
    public class DoubleBombHandler : BombTypeHandlerBase
    {
        public override void HandleBombType(int bombType, out int[,] result)
        {
            if (bombType == 2)
            {
                result = new DoubleBomb().Explosion;
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