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
            var minimumMines = Constants.MinimumPercentageOfBombs * size * size / 100;
            int maximumMines = (minimumMines * 2) + 1;
            int numberOfMines = RandomUtils.GenerateRandomNumber(minimumMines, maximumMines);
            var field1 = new Field(size, numberOfMines);
            var firstPlayerName = ConsoleInput.GetNameInput(1);
            var player1 = new Player(firstPlayerName, field1);
            var field2 = new Field(size, numberOfMines);
            var secondPlayerName = ConsoleInput.GetNameInput(2);
            var player2 = new Player(secondPlayerName, field2);
            var engine = new Engine(player1, player2);
            
            engine.Start(player1);
        }
    }
}
