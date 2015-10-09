namespace Battlefield.Logic.Common
{
    public struct Coordinates
    {
        public Coordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; }

        public int Col { get; }
    }
}
