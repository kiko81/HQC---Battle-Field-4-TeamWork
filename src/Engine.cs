namespace BattleField
{
    using System;

    using Common;
    using Fields;
    using InputProviders;
    using OutputProviders;

    public class Engine
    {
        public void InitiateGame()
        {
            ConsoleOutput.WelcomeMessage();

            int size = ConsoleInput.GetSizeInput();
            int[,] mineField = new int[size, size];
            var field1 = new Field(mineField);

            var minimumMines = Constants.MinimumPercentageOfMines * size * size / 100;

            Random rand = new Random();
            int maximumMines = (minimumMines * 2) + 1;

            int numberOfMines = rand.Next(minimumMines, maximumMines);

            field1.PlaceMines(numberOfMines);

            ConsoleOutput.Print(field1.ToString());
            
            int shotCount = 0;

            while (numberOfMines > 0)
            {
                int minesDetonated = field1.TakeAShot(field1.MineField);
                numberOfMines -= minesDetonated;
                ConsoleOutput.Print(field1.ToString());
                ConsoleOutput.Print(string.Format("Mines detonated this round: {0}", minesDetonated));
                shotCount++;
            }

            ConsoleOutput.WinningMessage(shotCount);
        }
    }
}
