namespace BattleField.Common
{
    public class Coordinates
    {
        public Coordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;

        }

        private int Col { get; set; }

        private int Row { get; set; }
    }
}
