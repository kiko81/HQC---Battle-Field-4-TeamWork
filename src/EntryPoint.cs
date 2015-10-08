namespace BattleField
{
    using Battlefield.Logic;

    public class EntryPoint
    {
        public static void Main()
        {
            var game = Game.Instance();
            game.Initiate();
        }
    }
}