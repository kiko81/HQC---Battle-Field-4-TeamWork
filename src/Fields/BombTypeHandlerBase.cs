using BattleField.GameObjects;

public abstract class BombTypeHandlerBase
{
    protected BombTypeHandlerBase _successor;

    public abstract void HandleBombType(int bombType, out int[,] result);

    public void SetSuccessor(BombTypeHandlerBase successor)
    {
        _successor = successor;
    }
}
