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

        public bool ChainReactionEnabled { get; set; }

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

        public int TakeAShot()
        {
            int x;
            int y;

            ConsoleInput.GetTargetCoordinates(Field.Size, out x, out y);

            var bombsDetonated = Field.Explode(x, y);

            var chainedMines = 0;
            if (this.ChainReactionEnabled)
            {
                this.ChainReactionEnabled = false;
                chainedMines += this.Field.ChainReact();
            }

            bombsDetonated += chainedMines;

            return bombsDetonated;
        }
    }
}