using System.Collections.Generic;
using Battlefield.Logic.GameObjects;

namespace Battlefield.Logic.Fields
{
    public interface IField
    {
        List<Cell> ChainedBombs { get; set; }
        Cell[,] Grid { get; set; }
        int NumberOfBombs { get; }
        int Size { get; }

        int Explode(Cell cell, bool chainEnabled);
        string ToString();
    }
}