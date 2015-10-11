namespace BattleField
{
    using Battlefield.Logic;

    public class EntryPoint
    {
        public static void Main()
        {
            //Entry point of the program
            var game = new Game();
            game.Initiate();
        }
    }
}