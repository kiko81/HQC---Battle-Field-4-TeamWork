namespace BattleField.GameObjects
{
    using System;

    using Common;

    public class Cell : ICloneable
    {
        public Cell(Coordinates coords)
        {
            this.Position = coords;
            this.Value = Constants.EmptyCell;
        }

        public Coordinates Position { get; set; }

        public int Value { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}