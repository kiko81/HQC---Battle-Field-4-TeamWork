namespace Battlefield.Logic.Fields
{
    using System.Collections.Generic;

    using Battlefield.Logic.GameObjects;

    using GameObjects.Bombs;

    /// <summary>
    /// Interface for field class.
    /// </summary>
    public interface IField
    {
        Cell[,] Grid { get; set; }

        int NumberOfBombs { get; }

        int Size { get; }

        bool InvertExplosion { get; set; }

        int Explode(Cell cell, bool chainEnabled, CompositeBomb chainedBombs);

        string ToString();
    }
}