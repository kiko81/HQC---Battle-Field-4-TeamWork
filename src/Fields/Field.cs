namespace BattleField.Fields
{
    using System.Text;

    using Common;

    public class Field
    {


        public Field(int[,] mineField)
        {
            this.MineField = mineField;
            this.Size = mineField.GetLength(0);
        }

        private int Size { get; set; }

        private int[,] MineField { get; set; }

        public string GenerateFieldSymbols()
        {
            var boardField = new StringBuilder();
            boardField.Append("  ");

            // horizontal indexing
            for (int i = 0; i < Size; i++)
            {
                boardField.AppendFormat(" {0}", i + 1);
            }

            boardField.AppendLine();
            // horizontal split
            boardField.Append("  ".PadRight((Size + 1) * 2 + 1, '-'));
            boardField.AppendLine();

            for (int i = 0; i < Size; i++)
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
                for (int j = 0; j < Size; j++)
                {
                    char symbol;
                    switch (MineField[i, j])
                    {
                        case Constants.EmptyField: symbol = '-'; break;
                        case Constants.BlownField: symbol = 'X'; break;
                        default: symbol = (char)('0' + MineField[i, j]); break;
                        //default: symbol = '-'; break;
                    }
                    boardField.AppendFormat("{0} ", symbol);
                }
                boardField.AppendLine();
            }

            return boardField.ToString();

        }
    }
}
