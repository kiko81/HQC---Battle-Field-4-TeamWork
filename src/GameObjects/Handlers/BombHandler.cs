namespace BattleField.GameObjects.Handlers
{
    public abstract class BombHandler
    {
        private BombHandler successor;

        protected BombHandler Successor
        {
            get { return this.successor; }
            private set { this.successor = value; }
        }

        //Check for commit
        public abstract void HandleBombType(int bombType, out int[,] result);

        public void SetSuccessor(BombHandler nextType)
        {
            this.successor = nextType;
        }
    }
}
