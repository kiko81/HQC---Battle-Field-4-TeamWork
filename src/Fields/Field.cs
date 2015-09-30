namespace BattleField.Fields
{
    using System.Text;

    using Common;
    using GameObjects;
    using InputProviders;

    public class Field
    {
        public Field(int size, int numberOfBombs)
        {
            this.Size = size;
            this.BombField = new int[size, size];
            this.NumberOfBombs = numberOfBombs;
            PlaceBombs(numberOfBombs);
        }

        private int Size { get; set; }

        public int NumberOfBombs { get; private set; }

        public int[,] BombField { get; private set; }

        public override string ToString()
        {
            var boardField = new StringBuilder();
            boardField.Append("  ");

            // horizontal indexing
            for (int col = 0; col < this.Size; col++)
            {
                boardField.AppendFormat(" {0}", col + 1);
            }

            boardField.AppendLine();
            // horizontal split
            boardField.Append("  ".PadRight((this.Size + 1) * 2 + 1, '-'));
            boardField.AppendLine();

            for (int row = 0; row < this.Size; row++)
            {
                // vertical indexing and splitting
                if (row < 9)
                {
                    boardField.AppendFormat("{0}".PadLeft(4, ' ') + "|", row + 1);
                }
                else
                {
                    boardField.AppendFormat("{0}|", row + 1);
                }

                // the field itself
                for (int col = 0; col < this.Size; col++)
                {
                    char symbol;
                    switch (BombField[row, col])
                    {
                        case Constants.EmptyCell: symbol = '-'; break;
                        case Constants.DetonatedCell: symbol = 'X'; break;
                        default: symbol = (char)('0' + BombField[row, col]); break;
                        //default: symbol = '-'; break;
                    }

                    boardField.AppendFormat("{0} ", symbol);
                }

                boardField.AppendLine();
            }

            return boardField.ToString();
        }

        private int Explode(int[,] field, int x, int y)
        {
            int[,] expl;
            switch (field[x, y]) // gets the type of bomb - will be reworked to chain of responsibility
            {
                case 1: expl = new SingleBomb().Explosion; break;
                case 2: expl = new DoubleBomb().Explosion; break;
                case 3: expl = new TripleBomb().Explosion; break;
                case 4: expl = new QuadBomb().Explosion; break;
                case 5: expl = new QuintBomb().Explosion; break;
                default: expl = new NoBomb().Explosion; break;
            }
            //bomb explodes
            var counter = 0;

            for (int i = Constants.BombDownLeftRange; i <= Constants.BombUpRightRange; i++)
            {
                for (int j = Constants.BombDownLeftRange; j <= Constants.BombUpRightRange; j++)
                {
                    if (x + i >= 0 && x + i < this.Size && y + j >= 0 && y + j < this.Size)
                    {
                        if (expl[i + 2, j + 2] == Constants.DetonationSpot)
                        {
                            if (field[x + i, y + j] > 0)
                            {
                                counter++;
                            }

                            field[x + i, y + j] = Constants.DetonatedCell;
                        }
                    }
                }
            }

            return counter;
        }

        public int TakeAShot(int[,] field)
        {
            int x;
            int y;

            ConsoleInput.GetTargetCoordinates(this.Size, out x, out y);

            // will be moved to NoBomb class
            //if (field[x, y] <= 0)
            //{
            //    field[x, y] = Constants.DetonatedCell;
            //    Console.WriteLine("No mine there");
            //    return 0;
            //}

            var bombsDetonated = Explode(field, x, y);

            return bombsDetonated;
        }

        private void PlaceBombs(int mineNumber)
        {
            for (int i = 0; i < mineNumber; i++)
            {
                int x = RandomUtils.GenerateRandomNumber(0, this.Size);
                int y = RandomUtils.GenerateRandomNumber(0, this.Size);

                while (this.BombField[x, y] != 0)
                {
                    x = RandomUtils.GenerateRandomNumber(0, this.Size);
                    y = RandomUtils.GenerateRandomNumber(0, this.Size);
                }

                this.BombField[x, y] = RandomUtils.GenerateRandomNumber(1, 6);
            }
        }
    }
}
