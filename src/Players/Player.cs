namespace BattleField.Players
{
    using Fields;

    public class Player
    {
        public Player(string name, Field field)
        {
            this.Name = name;
            this.Field = field.BombField;
        }

        public int[,] Field { get; private set; }

        private string Name { get; set; }
    }
}