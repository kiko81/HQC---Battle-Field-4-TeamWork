namespace Battlefield.Logic.Players
{
    using Battlefield.Logic.Contracts;
    using Battlefield.Logic.Fields;
    using Battlefield.Logic.GameObjects;

    public class Player
    {
        private readonly IInput input;

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
            // validate name
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