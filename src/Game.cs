namespace BattleField
{
    using Common;
    using Fields;
    using InputProviders;
    using OutputProviders;

    public class Game
    {
        private static Game game;

        private Game()
        {
        }

        public static Game Instance()
        {
            return game ?? (game = new Game());
        }

        public void Initiate()
        {
            ConsoleOutput.WelcomeMessage();
            var size = ConsoleInput.GetSizeInput();
            var minimumMines = Constants.MinimumPercentageOfBombs * size * size / 100;
            int maximumMines = minimumMines * 2 + 1;
            int numberOfMines = RandomUtils.GenerateRandomNumber(minimumMines, maximumMines);
            var field1 = new Field(size, numberOfMines);

            var engine = Engine.Instance();
            
            engine.Start(field1);
        }
    }
}
