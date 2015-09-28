namespace BattleField
{
    using System;

    using Common;
    using Fields;
    using InputProviders;
    using OutputProviders;

    public class Engine
    {
        public Field CreateField()
        {
            int size = ConsoleInput.GetSizeInput();
            int[,] mineField = new int[size, size];
            var field = new Field(mineField);

            var minimumMines = Constants.MinimumPercentageOfMines * size * size / 100;

            Random rand = new Random();
            int maximumMines = (minimumMines * 2) + 1;

            int numberOfMines = rand.Next(minimumMines, maximumMines);

            field.PlaceMines(numberOfMines);

            return field;
        }

        public void PrintField(Field field)
        {
            ConsoleOutput.Print(field.ToString());
        }

        public void PlayAtField(Field field)
        {
            int shotCount = 0;
            int numberOfMines = field.NumberOfMines();

            while (numberOfMines > 0)
            {
                int minesDetonated = field.TakeAShot(field.MineField);
                numberOfMines -= minesDetonated;
                ConsoleOutput.Print(field.ToString());
                ConsoleOutput.Print(string.Format("Mines detonated this round: {0}", minesDetonated));
                shotCount++;
            }

            ConsoleOutput.WinningMessage(shotCount);
        }
    }
}
