namespace BattleField.GameObjects.Handlers
{
    public abstract class BombTypeHandlerBase
    {
        private BombTypeHandlerBase successor;

        public BombTypeHandlerBase Successor
        {
            get { return this.successor; }
            private set { this.successor = value; }
        }

        public abstract void HandleBombType(int bombType, out int[,] result);

        public void SetSuccessor(BombTypeHandlerBase successor)
        {
            this.successor = successor;
        }
    }
}
