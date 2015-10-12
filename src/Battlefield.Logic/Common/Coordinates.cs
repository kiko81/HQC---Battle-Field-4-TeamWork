namespace Battlefield.Logic.Common
{
    /// <summary>
    /// Structure for holding coordinates.
    /// </summary>
    public struct Coordinates
    {
        /// <summary>
        /// Initializes a new instance of the Coordinates struct.
        /// </summary>
        /// <param name="row">Integer - row.</param>
        /// <param name="col">Integer - column.</param>
        public Coordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }

        public int Col { get; private set; }
    }
}
