namespace BattleField
{
    using System;
    using BattleField.OutputProviders;

    public class Game
    {
        private static Game game;

        private Game()
        {

        }

        public static Game CreateInstance()
        {
            if (game == null)
            {
                game = new Game();
            }

            return game;
        }

        public void Initiate()
        {
            var engine = new Engine();

            ConsoleOutput.WelcomeMessage();
            var field1 = engine.CreateField();
            engine.PrintField(field1);
            engine.PlayAtField(field1);
        }
    }
}
