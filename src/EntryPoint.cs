namespace BattleField
{
    using Fields;

    public class EntryPoint
    {
        static void Main()
        {
            var game = Game.CreateInstance();
            game.Initiate();
        }
    }
}

