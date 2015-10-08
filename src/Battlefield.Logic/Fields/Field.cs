<<<<<<< HEAD:src/Fields/Field.cs
﻿namespace BattleField.Fields
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Common;
    using GameObjects;
    using GameObjects.Handlers;

    public class Field
    {
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
                        case Constants.EmptyCell:
                            symbol = '-';
                            break;
                        case Constants.DetonatedCell:
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
            BombHandler bomb1 = new SingleBombHandler();
            BombHandler bomb2 = new DoubleBombHandler();
            BombHandler bomb3 = new TripleBombHandler();
            BombHandler bomb4 = new QuadBombHandler();
            BombHandler bomb5 = new QuintBombHandler();
            BombHandler bomb6 = new XBombHandler();
            BombHandler bomb7 = new VerticalBombHandler();
            BombHandler bomb8 = new HorizontalBombHandler();

            bomb1.SetSuccessor(bomb2);
            bomb2.SetSuccessor(bomb3);
            bomb3.SetSuccessor(bomb4);
            bomb4.SetSuccessor(bomb5);
            bomb5.SetSuccessor(bomb6);
            bomb6.SetSuccessor(bomb7);
            bomb7.SetSuccessor(bomb8);

            var col = cell.Position.Col;
            var row = cell.Position.Row;
            int[,] explosion;

            if (cell.Value == 0)
            {
                cell.Value = this.Grid[col, row].Value;
            }

            bomb1.HandleBombType(cell.Value, out explosion);

            // bomb explodes
            var minesExplodedThisRound = 0;

            for (var i = Constants.BombDownLeftRange; i <= Constants.BombUpRightRange; i++)
            {
                for (var j = Constants.BombDownLeftRange; j <= Constants.BombUpRightRange; j++)
                {
                    if (col + i >= 0 && col + i < this.Size && row + j >= 0 && row + j < this.Size)
                    {
                        if (explosion[i + 2, j + 2] == Constants.DetonationSpot)
                        {
                            if (this.Grid[col + i, row + j].Value > 0)
                            {
                                if (chainEnabled)
                                {
                                    // Fills list with cells for iterating explosions over it
                                    var clonedCell = this.Grid[col + i, row + j].Clone() as Cell;
                                    this.ChainedBombs.Add(clonedCell);
                                    continue;
                                }

                                minesExplodedThisRound++;
                            }

                            this.Grid[col + i, row + j].Value = Constants.DetonatedCell;
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

                this.Grid[x, y].Value = RandomUtils.GenerateRandomNumber(1, Constants.KindsOfBombs);
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
=======
﻿namespace BattleField.Fields
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Common;
    using GameObjects;
    using GameObjects.Handlers;

    public class Field
    {
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
                        case Constants.EmptyCell:
                            symbol = '-';
                            break;
                        case Constants.DetonatedCell:
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
            BombHandler bomb1 = new SingleBombHandler();
            BombHandler bomb2 = new DoubleBombHandler();
            BombHandler bomb3 = new TripleBombHandler();
            BombHandler bomb4 = new QuadBombHandler();
            BombHandler bomb5 = new QuintBombHandler();
            BombHandler bomb6 = new XBombHandler();
            BombHandler bomb7 = new VerticalBombHandler();
            BombHandler bomb8 = new HorizontalBombHandler();

            bomb1.SetSuccessor(bomb2);
            bomb2.SetSuccessor(bomb3);
            bomb3.SetSuccessor(bomb4);
            bomb4.SetSuccessor(bomb5);
            bomb5.SetSuccessor(bomb6);
            bomb6.SetSuccessor(bomb7);
            bomb7.SetSuccessor(bomb8);

            var col = cell.Position.Col;
            var row = cell.Position.Row;
            int[,] explosion;

            if (cell.Value == 0)
            {
                cell.Value = this.Grid[col, row].Value;
            }

            bomb1.HandleBombType(cell.Value, out explosion);

            // bomb explodes
            var minesExplodedThisRound = 0;

            for (var i = Constants.BombDownLeftRange; i <= Constants.BombUpRightRange; i++)
            {
                for (var j = Constants.BombDownLeftRange; j <= Constants.BombUpRightRange; j++)
                {
                    if (col + i >= 0 && col + i < this.Size && row + j >= 0 && row + j < this.Size)
                    {
                        if (explosion[i + 2, j + 2] == Constants.DetonationSpot)
                        {
                            if (this.Grid[col + i, row + j].Value > 0)
                            {
                                if (chainEnabled)
                                {
                                    // Fills list with cells for iterating explosions over it
                                    var clonedCell = this.Grid[col + i, row + j].Clone() as Cell;
                                    this.ChainedBombs.Add(clonedCell);
                                    continue;
                                }

                                minesExplodedThisRound++;
                            }

                            this.Grid[col + i, row + j].Value = Constants.DetonatedCell;
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

                this.Grid[x, y].Value = RandomUtils.GenerateRandomNumber(1, Constants.KindsOfBombs);
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
>>>>>>> f50b268fcf24e49ae73de27ec3b7c086daf0b4ff:src/Battlefield.Logic/Fields/Field.cs
}