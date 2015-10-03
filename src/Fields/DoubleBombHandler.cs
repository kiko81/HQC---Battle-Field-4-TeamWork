using BattleField.GameObjects;

public class DoubleBombHandler : BombTypeHandlerBase
{
    public override void HandleBombType(int bombType, out int[,] result)
    {
        if (bombType == 2)
        {
            result = new DoubleBomb().Explosion;
        }
        else if (_successor != null)
        {
            _successor.HandleBombType(bombType, out result);
        }
        else
        {
            result = new NoBomb().Explosion;
        }
    }
}