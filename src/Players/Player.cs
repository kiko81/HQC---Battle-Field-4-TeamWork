namespace BattleField.Players
{
    using Fields;

    using InputProviders;

    public class Player
    {
        private string name;
        private int shotCount;

        public Player(string name, Field field)
        {
            this.Name = name;
            this.Field = field;
            this.NumberOfBombs = field.NumberOfBombs;
            this.ShotCount = 0;
        }

        public int NumberOfBombs { get; set; }

        public Field Field { get; private set; }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int ShotCount
        {
            get { return this.shotCount; }
            set { this.shotCount = value; }
        }

        public int TakeAShot(int[,] field)
        {
            int x;
            int y;

            ConsoleInput.GetTargetCoordinates(this.Field.Size, out x, out y);

            var bombsDetonated = this.Field.Explode(field, x, y);

            return bombsDetonated;
        }
    }
}