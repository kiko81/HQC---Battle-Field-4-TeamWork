namespace BattleField.Common
{
    public struct Coordinates
    {
        private readonly int row;
        private readonly int col;

        public Coordinates(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public int Row
        {
            get
            {
                return this.row;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }
        }
    }
}
