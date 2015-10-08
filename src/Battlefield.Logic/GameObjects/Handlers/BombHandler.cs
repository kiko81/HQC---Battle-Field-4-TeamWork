namespace Battlefield.Logic.GameObjects.Handlers
{
    public abstract class BombHandler
    {
        private BombHandler successor;

        protected BombHandler Successor
        {
            get { return this.successor; }
            private set { this.successor = value; }
        }

        public static BombHandler SetBombChain()
        {
            BombHandler bomb1 = new SingleBombHandler();
            BombHandler bomb2 = new DoubleBombHandler();
            BombHandler bomb3 = new TripleBombHandler();
            BombHandler bomb4 = new QuadBombHandler();
            BombHandler bomb5 = new QuintBombHandler();
            BombHandler bomb6 = new XBombHandler();
            BombHandler bomb7 = new VerticalBombHandler();
            BombHandler bomb8 = new HorizontalBombHandler();

            bomb1.SetSuccessor(bomb2);
            bomb2.SetSuccessor(bomb3);
            bomb3.SetSuccessor(bomb4);
            bomb4.SetSuccessor(bomb5);
            bomb5.SetSuccessor(bomb6);
            bomb6.SetSuccessor(bomb7);
            bomb7.SetSuccessor(bomb8);

            return bomb1;
        }

        public abstract int[,] HandleBombType(int bombType);

        private void SetSuccessor(BombHandler nextType)
        {
            this.successor = nextType;
        }
    }
}
