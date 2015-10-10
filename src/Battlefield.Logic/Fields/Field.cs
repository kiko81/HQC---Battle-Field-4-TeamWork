namespace Battlefield.Logic.Fields
{
    using System.Collections.Generic;
    using System.Text;

    using Battlefield.Logic.GameObjects;

    using Common;

    public class Field : IField
    {
        private const int EmptyCell = 0;
        private const int DetonatedCell = -1;
        private const int BombDownLeftRange = -2;
        private const int BombUpRightRange = 2;
        private const int DetonationSpot = 1;
        private const int KindsOfBombs = 9;

        public Field(int size, int numberOfBombs)
        {
            this.Size = size;
            this.Grid = new Cell[size, size];
            this.FillFieldWithEmptyCells();
            this.NumberOfBombs = numberOfBombs;
            this.PlaceBombs(numberOfBombs);
            this.ChainedBombs = new List<Cell>();
        }

        public int NumberOfBombs { get; private set; }

        public int Size { get; private set; }

        public Cell[,] Grid { get; set; }

        public List<Cell> ChainedBombs { get; set; }

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
                        default:
                            symbol = (char)('0' + this.Grid[row, col].Value);
                            break;
                            ////default: symbol = '-'; break;
                    }

                    playField.AppendFormat("{0} ", symbol);
                }

                playField.AppendLine();
            }

            return playField.ToString();
        }

        public int Explode(Cell cell, bool chainEnabled)
        {
            var col = cell.Position.Col;
            var row = cell.Position.Row;

            if (cell.Value == 0)
            {
                cell.Value = this.Grid[col, row].Value;
            }

            var bomb = new ExplosionStrategy(cell.Value);

            var explosion = bomb.GetExplosion();

            // bomb explodes
            var minesExplodedThisRound = 0;

            for (var i = BombDownLeftRange; i <= BombUpRightRange; i++)
            {
                for (var j = BombDownLeftRange; j <= BombUpRightRange; j++)
                {
                    if (col + i >= 0 && col + i < this.Size && row + j >= 0 && row + j < this.Size)
                    {
                        if (explosion[i + 2, j + 2] == DetonationSpot)
                        {
                            if (this.Grid[col + i, row + j].Value > 0)
                            {
                                if (chainEnabled)
                                {
                                    // Fills list with cells for iterating explosions over it
                                    var clonedCell = this.Grid[col + i, row + j].Clone() as Cell;
                                    this.ChainedBombs.Add(clonedCell);
                                }
                                else
                                {
                                    minesExplodedThisRound++;
                                }
                            }

                            this.Grid[col + i, row + j].Value = DetonatedCell;
                        }
                    }
                }
            }

            return minesExplodedThisRound;
        }

        private void PlaceBombs(int mineNumber)
        {
            for (var i = 0; i < mineNumber; i++)
            {
                var x = RandomUtils.GenerateRandomNumber(0, this.Size);
                var y = RandomUtils.GenerateRandomNumber(0, this.Size);

                while (this.Grid[x, y].Value != 0)
                {
                    x = RandomUtils.GenerateRandomNumber(0, this.Size);
                    y = RandomUtils.GenerateRandomNumber(0, this.Size);
                }

                this.Grid[x, y].Value = RandomUtils.GenerateRandomNumber(1, KindsOfBombs);
            }
        }

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