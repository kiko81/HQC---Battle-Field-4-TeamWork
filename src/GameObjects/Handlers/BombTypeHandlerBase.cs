namespace BattleField.GameObjects.Handlers
{
    public abstract class BombTypeHandlerBase
    {
        protected BombTypeHandlerBase successor;

        public abstract void HandleBombType(int bombType, out int[,] result);

        public void SetSuccessor(BombTypeHandlerBase successor)
        {
            this.successor = successor;
        }
    }
}
