namespace BattleField.GameObjects
{
    using Common;

    public class Cell
    {
        public Cell(Coordinates coords)
        {
            this.Position = coords;
        }

        public Coordinates Position { get; set; }

        public int Value { get; set; }
    }
}