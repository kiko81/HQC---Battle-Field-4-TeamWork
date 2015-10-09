namespace Battlefield.Logic.GameObjects
{
    using System;

    using Battlefield.Logic.Common;

    public class Cell : ICloneable
    {
        public Cell(Coordinates coordinates)
        {
            this.Position = coordinates;
            this.Value = Constants.EmptyCell;
        }

        public Coordinates Position { get; private set; }

        public int Value { get; set; }

        //private object DeepCopy()
        //{
        //    var deepCopy = this.MemberwiseClone();
        //    return deepCopy;
        //}

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}