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
            int mineNumber = rand.Next(minimumMines, minimumMines * 2 + 1);

            field1.PlaceMines(mineNumber);

            ConsoleOutput.Print(field1.ToString());
            
            int numberOfShots = 0;

            while (mineNumber > 0)
            {
                int tmp = field1.TakeAShot(field1.MineField);
                mineNumber -= tmp;
                ConsoleOutput.Print(field1.ToString());
                ConsoleOutput.Print(string.Format("Mines detonated this round: {0}", tmp));
                numberOfShots++;
            }

            ConsoleOutput.WinningMessage(numberOfShots);
        }
    }
}
