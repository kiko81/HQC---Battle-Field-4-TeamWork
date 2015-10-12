namespace Battlefield.Logic.Fields
{
    using System.Collections.Generic;
    using System.Text;

    using Battlefield.Logic.Common;
    using Battlefield.Logic.GameObjects;

    /// <summary>
    /// Field class holding the playfield.
    /// </summary>
    public class Field : IField
    {
        private const int EmptyCell = 0;
        private const int DetonatedCell = -1;
        private const int BombRadius = 2;
        private const int DetonationSpot = 1;
        private const int KindsOfBombs = 8;

        public Field(int size, int numberOfBombs)
        {
            this.Size = size;
            this.Grid = new Cell[size, size];
            this.FillFieldWithEmptyCells();
            this.NumberOfBombs = numberOfBombs;
            this.PlaceBombs(numberOfBombs);
        }

        public int NumberOfBombs { get; private set; }

        public int Size { get; private set; }

        public bool InvertExplosion { get; set; }

        public Cell[,] Grid { get; set; }

        /// <summary>
        /// ToString overriding.
        /// </summary>
        /// <returns>String ready for printing.</returns>
        public override string ToString()
        {
            var playField = new StringBuilder();
            playField.Append("  ");

            // horizontal indexing
            for (var col = 0; col < this.Size; col++)
            {
                playField.AppendFormat(" {0}", (char)(col + 'A'));
            }

            playField.AppendLine();

            // horizontal split
            playField.Append("  ".PadRight((this.Size + 1) * 2, '-'));
            playField.AppendLine();

            for (var row = 0; row < this.Size; row++)
            {
                // vertical indexing and splitting
                if (row < 9)
                {
                    playField.AppendFormat("{0}".PadLeft(4, ' ') + "|", row + 1);
                }
                else
                {
                    playField.AppendFormat("{0}|", row + 1);
                }

                // the field itself
                for (var col = 0; col < this.Size; col++)
                {
                    char symbol;
                    switch (this.Grid[row, col].Value)
                    {
                        case EmptyCell:
                            symbol = '-';
                            break;
                        case DetonatedCell:
                            symbol = 'x';
                            break;
                        default: symbol = '-';
                            break;
                            //// default:
                            //    symbol = (char)('0' + this.Grid[row, col].Value);
                            //    break;
                    }

                    playField.AppendFormat("{0} ", symbol);
                }

                playField.AppendLine();
            }

            return playField.ToString();
        }

        /// <summary>
        /// Handling explosions.
        /// </summary>
        /// <param name="cell">Coordinates and eventually value of the cell.</param>
        /// <param name="chainEnabled">Boolean value if chain reaction enabled.</param>
        /// <param name="chainedBombs">Array for holding chained bombs.</param>
        /// <returns>Number of bombs detonated.</returns>
        public int Explode(Cell cell, bool chainEnabled, CompositeBomb chainedBombs)
        {
            var fieldRow = cell.Position.Row;
            var fieldCol = cell.Position.Col;

            // by default cell comes with coordinates only - ex. ChainReaction
            if (cell.Value == 0)
            {
                cell.Value = this.Grid[fieldRow, fieldCol].Value;

                // if no bomb  - detonate the cell and exit the method 
                if (cell.Value == 0)
                {
                    this.Grid[fieldRow, fieldCol].Value = DetonatedCell;
                    return 0;
                }
            }

            var bomb = new ExplosionStrategy(cell.Value);
            var explosion = this.InvertExplosion ? bomb.GetInvertedExplosion() : bomb.GetExplosion();

            this.InvertExplosion = false;

            var minesExplodedThisRound = 0;

            // bomb explodes
            for (var explosionRow = -BombRadius; explosionRow <= BombRadius; explosionRow++)
            {
                for (var explosionCol = -BombRadius; explosionCol <= BombRadius; explosionCol++)
                {
                    if (Validators.IsInBounds(fieldRow + explosionRow, this.Size) &&
                        Validators.IsInBounds(fieldCol + explosionCol, this.Size))
                    {
                        if (explosion[explosionRow + BombRadius, explosionCol + BombRadius] == DetonationSpot)
                        {
                            if (this.Grid[fieldRow + explosionRow, fieldCol + explosionCol].Value > EmptyCell)
                            {
                                if (chainEnabled)
                                {
                                    var clonedCell = this.Grid[fieldRow + explosionRow, fieldCol + explosionCol].Clone() as Cell;
                                    chainedBombs.Add(clonedCell);
                                    continue;
                                }

                                minesExplodedThisRound++;
                            }

                            this.Grid[fieldRow + explosionRow, fieldCol + explosionCol].Value = DetonatedCell;
                        }
                    }
                }
            }

            return minesExplodedThisRound;
        }

        /// <summary>
        /// Method arming the field with bombs.
        /// </summary>
        /// <param name="mineNumber">The number of mines to arm</param>
        private void PlaceBombs(int mineNumber)
        {
            for (var mine = 0; mine < mineNumber; mine++)
            {
                var row = RandomUtils.GenerateRandomNumber(0, this.Size - 1);
                var col = RandomUtils.GenerateRandomNumber(0, this.Size - 1);

                while (this.Grid[row, col].Value != 0)
                {
                    row = RandomUtils.GenerateRandomNumber(0, this.Size - 1);
                    col = RandomUtils.GenerateRandomNumber(0, this.Size - 1);
                }

                this.Grid[row, col].Value = RandomUtils.GenerateRandomNumber(1, KindsOfBombs);
            }
        }

        /// <summary>
        /// Filling playfield with empty cells.
        /// </summary>
        private void FillFieldWithEmptyCells()
        {
            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    this.Grid[row, col] = new Cell(new Coordinates(row, col));
                }
            }
        }
    }
}