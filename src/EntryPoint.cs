namespace BattleField
{
    public class EntryPoint
    {
        public static void Main()
        {
            var game = Game.Instance();
            game.Initiate();
        }
    }
}