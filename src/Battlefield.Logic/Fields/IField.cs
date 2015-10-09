﻿namespace Battlefield.Logic.Fields
{
    using System.Collections.Generic;

    using Battlefield.Logic.GameObjects;

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