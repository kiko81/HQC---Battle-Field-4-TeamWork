namespace BattleField.Common
{
    public struct Coordinates
    {
        public Coordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        // both properties for validation only, when so remove getters - teammates welcome
        private int Col { get; set; }

        private int Row { get; set; }
    }
}
