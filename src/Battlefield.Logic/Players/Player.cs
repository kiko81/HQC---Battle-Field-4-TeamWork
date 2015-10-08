namespace BattleField.Players
{
    using Fields;

    using GameObjects;

    using InputProviders;

    public class Player
<<<<<<< HEAD:src/Players/Player.cs
    {
=======
    {
>>>>>>> f50b268fcf24e49ae73de27ec3b7c086daf0b4ff:src/Battlefield.Logic/Players/Player.cs
        private readonly IInput input;
        private string name;

        private string name;

        public Player(string name, Field field, IInput input)
        {
            this.Name = name;
            this.Field = field;
            this.input = input;
            this.NumberOfBombs = field.NumberOfBombs;
            this.ShotCount = 0;
        }

        public int NumberOfBombs { get; set; }

        public Field Field { get; private set; }

        public bool ChainReactionEnabled { get; set; }

        public string Name
        {
            get { return this.name; }
            //// validate name
            private set { this.name = value; }
        }

        public int ShotCount { get; set; }

        public int TakeAShot()
        {
            var coordinates = this.input.GetTargetCoordinates();

            var bombsDetonated = Field.Explode(new Cell(coordinates), this.ChainReactionEnabled);

            if (this.ChainReactionEnabled)
            {
                this.ChainReactionEnabled = false;

                foreach (var bomb in this.Field.ChainedBombs)
                {
                    bombsDetonated += Field.Explode(bomb, this.ChainReactionEnabled);
                }

                this.Field.ChainedBombs.Clear();
            }

            return bombsDetonated;
        }
    }
}