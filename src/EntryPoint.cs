namespace BattleField
{
    using Battlefield.Logic;

    public class EntryPoint
    {
        public static void Main()
        {
            var game = new Game();
            game.Initiate();
        }
    }
}