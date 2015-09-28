namespace BattleField.Fields
{
    using System;
    using System.Text;

    using Common;
    using GameObjects;
    using InputProviders;

    public class Field
    {
        private readonly int size;
        private int numberOfMines;

        public Field(int[,] mineField)
        {
            this.MineField = mineField;
            this.size = mineField.GetLength(0);
        }

        public int[,] MineField { get; private set; }

        public override string ToString()
        {
            var boardField = new StringBuilder();
            boardField.Append("  ");

            // horizontal indexing
            for (int i = 0; i < size; i++)
            {
                boardField.AppendFormat(" {0}", i + 1);
            }

            boardField.AppendLine();
            // horizontal split
            boardField.Append("  ".PadRight((size + 1) * 2 + 1, '-'));
            boardField.AppendLine();

            for (int i = 0; i < size; i++)
            {
                // vertical indexing and splitting
                if (i < 9)
                {
                    boardField.AppendFormat("{0}".PadLeft(4, ' ') + "|", i + 1);
                }
                else
                {
                    boardField.AppendFormat("{0}|", i + 1);
                }

                // the field itself
                for (int j = 0; j < size; j++)
                {
                    char symbol;
                    switch (MineField[i, j])
                    {
                        case Constants.EmptyCell: symbol = '-'; break;
                        case Constants.DetonatedCell: symbol = 'X'; break;
                        default: symbol = (char)('0' + MineField[i, j]); break;
                        //default: symbol = '-'; break;
                    }

                    boardField.AppendFormat("{0} ", symbol);
                }

                boardField.AppendLine();
            }

            return boardField.ToString();
        }

        private int Explode(int[,] arr, int x, int y)
        {
            int[,] expl;
            switch (arr[x, y]) // gets the type of bomb
            {
                case 1: expl = new SingleMine().Explosion; break;
                case 2: expl = new DoubleMine().Explosion; break;
                case 3: expl = new TripleMine().Explosion; break;
                case 4: expl = new QuadMine().Explosion; break;
                case 5: expl = new QuintMine().Explosion; break;
                default: throw new ArgumentException("No mine in this field");
            }
            //bomb explodes
            int counter = 0;

            for (int i = Constants.BombDownLeftRange; i <= Constants.BombUpRightRange; i++)
            {
                for (int j = Constants.BombDownLeftRange; j <= Constants.BombUpRightRange; j++)
                {
                    if (x + i >= 0 && x + i < size && y + j >= 0 && y + j < size)
                    {
                        if (expl[i + 2, j + 2] == Constants.DetonationSpot)
                        {
                            if (arr[x + i, y + j] > 0)
                            {
                                counter++;
                            }

                            arr[x + i, y + j] = Constants.DetonatedCell;
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

            ConsoleInput.GetTargetCoordinates(size, out x, out y);

            if (field[x, y] <= 0)
            {
                field[x, y] = Constants.DetonatedCell;
                Console.WriteLine("No Bomb there");
                return 0;
            }

            var minesDetonated = Explode(field, x, y);

            return minesDetonated;
        }

        public int NumberOfMines()
        {
            return this.numberOfMines;
        }

        internal void PlaceMines(int mineNumber)
        {
            this.numberOfMines = mineNumber;

            Random rand = new Random();

            for (int i = 0; i < mineNumber; i++)
            {
                int x = rand.Next(0, size);
                int y = rand.Next(0, size);

                while (this.MineField[x, y] != 0)
                {
                    x = rand.Next(0, size);
                    y = rand.Next(0, size);
                }

                this.MineField[x, y] = rand.Next(1, 6);
            }
        }
    }
}
