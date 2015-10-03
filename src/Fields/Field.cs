namespace BattleField.Fields
{
    using System.Text;

    using Common;
    using GameObjects;

    public class Field
    {
        public Field(int size, int numberOfBombs)
        {
            this.Size = size;
            this.Grid = new int[size, size];
            this.NumberOfBombs = numberOfBombs;
            this.PlaceBombs(numberOfBombs);
        }

        public int NumberOfBombs { get; private set; }

        public int[,] Grid { get; private set; }

        public int Size { get; private set; }

        public override string ToString()
        {
            var playField = new StringBuilder();
            playField.Append("  ");

            // horizontal indexing
            for (int col = 0; col < this.Size; col++)
            {
                playField.AppendFormat(" {0}", (char)(col + 'A'));
            }

            playField.AppendLine();

            // horizontal split
            playField.Append("  ".PadRight(((this.Size + 1) * 2) + 1, '-'));
            playField.AppendLine();

            for (int row = 0; row < this.Size; row++)
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
                for (int col = 0; col < this.Size; col++)
                {
                    char symbol;
                    switch (this.Grid[row, col])
                    {
                        case Constants.EmptyCell:
                            symbol = '-';
                            break;
                        case Constants.DetonatedCell:
                            symbol = 'X';
                            break;
                        default:
                            symbol = (char)('0' + this.Grid[row, col]);
                            break;
                            //default: symbol = '-'; break;
                    }

                    playField.AppendFormat("{0} ", symbol);
                }

                playField.AppendLine();
            }

            return playField.ToString();
        }

        public int Explode(int[,] field, int x, int y)
        {
            int[,] expl ={
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 }
        };

            BombTypeHandlerBase bomb1 = new SingleBombHandler();
            BombTypeHandlerBase bomb2 = new DoubleBombHandler();
            BombTypeHandlerBase bomb3 = new TripleBombHandler();
            BombTypeHandlerBase bomb4 = new QuadBombHandler();
            BombTypeHandlerBase bomb5 = new QuintBombHandler();

            bomb1.SetSuccessor(bomb2);
            bomb2.SetSuccessor(bomb3);
            bomb3.SetSuccessor(bomb4);
            bomb4.SetSuccessor(bomb5);

            bomb1.HandleBombType(field[x, y], out expl);

            // bomb explodes
            var minesExplodedThisRound = 0;

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
                                minesExplodedThisRound++;
                            }

                            field[x + i, y + j] = Constants.DetonatedCell;
                        }
                    }
                }
            }

            return minesExplodedThisRound;
        }

        private void PlaceBombs(int mineNumber)
        {
            for (int i = 0; i < mineNumber; i++)
            {
                int x = RandomUtils.GenerateRandomNumber(0, this.Size);
                int y = RandomUtils.GenerateRandomNumber(0, this.Size);

                while (this.Grid[x, y] != 0)
                {
                    x = RandomUtils.GenerateRandomNumber(0, this.Size);
                    y = RandomUtils.GenerateRandomNumber(0, this.Size);
                }

                this.Grid[x, y] = RandomUtils.GenerateRandomNumber(1, 6);
            }
        }
    }
}
