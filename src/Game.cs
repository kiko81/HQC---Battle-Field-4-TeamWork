namespace BattleField
{
    using System;
    using BattleField.OutputProviders;

    using Common;

    using Fields;

    using InputProviders;

    public class Game
    {
        Random rand = new Random();

        private static Game game;

        private Game()
        {
        }

        public static Game CreateInstance()
        {
            return game ?? (game = new Game());
        }

        public void Initiate()
        {
            ConsoleOutput.WelcomeMessage();
            var size = ConsoleInput.GetSizeInput();
            var minimumMines = Constants.MinimumPercentageOfMines * size * size / 100;
            int maximumMines = (minimumMines * 2) + 1;
            int numberOfMines = rand.Next(minimumMines, maximumMines);
            var field1 = new Field(size, numberOfMines);

            var engine = new Engine();
            
            engine.PrintField(field1);
            engine.PlayAtField(field1);
        }
    }
}
