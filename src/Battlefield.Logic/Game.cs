namespace Battlefield.Logic
{
    using Battlefield.Logic.Common;
    using Battlefield.Logic.Engines;
    using Battlefield.Logic.Fields;
    using Battlefield.Logic.InputProviders;
    using Battlefield.Logic.OutputProviders;
    using Battlefield.Logic.Players;

    /// <summary>
    /// Class holding facade method.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Facade method initializing all needed for the game and starting it.
        /// </summary>
        public void Initiate()
        {
            ConsoleOutput.PrintWelcomeMessage();

            var size = ConsoleInput.GetSizeInput();
            IInput consoleInput = new ConsoleInput(size);
            var minimumMines = Constants.MinimumPercentageOfBombs * size * size / 100;
            var maximumMines = minimumMines * 2;
            var numberOfMines = RandomUtils.GenerateRandomNumber(minimumMines, maximumMines);

            IField field1 = new Field(size, numberOfMines);
            var firstPlayerName = consoleInput.GetNameInput("first");
            IPlayer player1 = new Player(firstPlayerName, field1, consoleInput);

            IField field2 = new Field(size, numberOfMines);
            var secondPlayerName = consoleInput.GetNameInput("second");
            IPlayer player2 = new Player(secondPlayerName, field2, consoleInput);

            IEngine consoleEngine = new ConsoleEngine(player1, player2);
            
            consoleEngine.Start(player1);
        }
    }
}
