namespace BattleField
{
    using Common;
    using Fields;
    using InputProviders;
    using OutputProviders;
    using Players;

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
            IInput consoleInput= new ConsoleInput(size);
            var minimumMines = Constants.MinimumPercentageOfBombs * size * size / 100;
            var maximumMines = (minimumMines * 2) + 1;
            var numberOfMines = RandomUtils.GenerateRandomNumber(minimumMines, maximumMines);

            var field1 = new Field(size, numberOfMines);
            var firstPlayerName = consoleInput.GetNameInput("first");
            var player1 = new Player(firstPlayerName, field1, consoleInput);

            var field2 = new Field(size, numberOfMines);
            var secondPlayerName = consoleInput.GetNameInput("second");
            var player2 = new Player(secondPlayerName, field2, consoleInput);

            var engine = new Engine(player1, player2);
            
            engine.Start(player1);
        }
    }
}
