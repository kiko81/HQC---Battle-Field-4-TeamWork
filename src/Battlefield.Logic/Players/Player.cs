namespace Battlefield.Logic.Players
{
    using System;

    using Battlefield.Logic.Fields;
    using Battlefield.Logic.GameObjects;
    using Battlefield.Logic.InputProviders;

    public class Player : IPlayer
    {
        private const string StringCannotBeNullOrEmpty = "Name cannot be null or empty!";

        private IInput input;

        private string name;

        public Player(string name, IField field, IInput input)
        {
            this.Name = name;
            this.Field = field;
            this.input = input;
            this.NumberOfBombs = field.NumberOfBombs;
            this.ShotCount = 0;
        }

        public IField Field { get; private set; }

        public int NumberOfBombs { get; set; }

        public bool ChainReactionEnabled { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(StringCannotBeNullOrEmpty);
                }

                this.name = value;
            }
        }

        public int ShotCount { get; set; }

        public int TakeAShot()
        {
            var coordinates = this.input.GetTargetCoordinates();

            var bombsDetonated = this.Field.Explode(new Cell(coordinates), this.ChainReactionEnabled);

            if (this.ChainReactionEnabled)
            {
                this.ChainReactionEnabled = false;

                foreach (var bomb in this.Field.ChainedBombs)
                {
                    bombsDetonated += this.Field.Explode(bomb, false);
                }

                this.Field.ChainedBombs.Clear();
            }

            return bombsDetonated;
        }
    }
}