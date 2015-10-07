namespace BattleField.Fields
{
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
            this.ChainedMines = new List<Cell>();
        }

        public int NumberOfBombs { get; private set; }

        public int Size { get; private set; }

        private Cell[,] Grid { get; set; }

        private List<Cell> ChainedMines { get; set; }

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

        public int Explode(int x, int y, bool chainEnabled)
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

            int[,] expl;

            bomb1.HandleBombType(this.Grid[x, y].Value, out expl);

            // bomb explodes
            var minesExplodedThisRound = 0;

            for (var i = Constants.BombDownLeftRange; i <= Constants.BombUpRightRange; i++)
            {
                for (var j = Constants.BombDownLeftRange; j <= Constants.BombUpRightRange; j++)
                {
                    if (x + i >= 0 && x + i < this.Size && y + j >= 0 && y + j < this.Size)
                    {
                        if (expl[i + 2, j + 2] == Constants.DetonationSpot)
                        {
                            if (this.Grid[x + i, y + j].Value > 0)
                            {
                                if (chainEnabled)
                                {
                                    // Fills array with cells and skips changing the grid - lefts the changes to chain reactions
                                    this.ChainedMines.Add(new Cell(new Coordinates(x + i, y + j)));
                                    continue;
                                }

                                minesExplodedThisRound++;
                            }

                            this.Grid[x + i, y + j].Value = Constants.DetonatedCell;
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

        public int ChainReact()
        {
            var minesExplodedThisRound = 0;

            foreach (var chainedMine in this.ChainedMines)
            {
                ////minesExplodedThisRound += Explode(chainedMine.X, chainedMine.Y, false);
            }

            return minesExplodedThisRound;
        }
    }
}