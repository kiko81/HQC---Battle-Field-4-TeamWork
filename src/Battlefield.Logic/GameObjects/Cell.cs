namespace Battlefield.Logic.GameObjects
{
    using System;

    using Battlefield.Logic.Common;

    public class Cell : ICloneable
    {
        protected Cell()
        {
        }

        public Cell(Coordinates coordinates)
        {
            this.Position = coordinates;
        }

        public Coordinates Position { get; private set; }

        public int Value { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}