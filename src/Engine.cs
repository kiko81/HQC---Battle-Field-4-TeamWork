namespace BattleField
{
    using Fields;
    using OutputProviders;

    public class Engine
    {
        private static Engine engine;

        private Engine()
        {
        }

        public static Engine Instance()
        {
            return engine ?? (engine = new Engine());
        }

        public void Start(Field field)
        {
            this.PrintField(field);
            this.UpdateGame(field);
        }

        private void PrintField(Field field)
        {
            ConsoleOutput.Print(field.ToString());
        }

        private void UpdateGame(Field field)
        {
            int shotCount = 0;
            int numberOfBombs = field.NumberOfBombs;

            while (numberOfBombs > 0)
            {
                int minesDetonated = field.TakeAShot(field.BombField);
                numberOfBombs -= minesDetonated;
                ConsoleOutput.Print(field.ToString());
                ConsoleOutput.Print(string.Format("Mines detonated this round: {0}", minesDetonated));
                shotCount++;
            }

            ConsoleOutput.WinningMessage(shotCount);
        }
    }
}
