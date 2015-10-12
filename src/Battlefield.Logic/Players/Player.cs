namespace Battlefield.Logic.Players
{
    using System;

    using Battlefield.Logic.Fields;
    using Battlefield.Logic.GameObjects;
    using Battlefield.Logic.InputProviders;

    /// <summary>
    /// A player class
    /// </summary>
    public class Player : IPlayer
    {
        private const string StringCannotBeNullOrEmpty = "Name cannot be null or empty!";

        private IInput input;

        private string name;

        /// <summary>
        /// Constructor for initialization of plyers.
        /// </summary>
        /// <param name="name">Name of the player.</param>
        /// <param name="field">The player's playfield.</param>
        /// <param name="input">Input object for receiving commands.</param>
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

        /// <summary>
        /// Player shoots in playfield
        /// </summary>
        /// <returns>Bombs detonated.</returns>
        public int TakeAShot()
        {
            var coordinates = this.input.GetTargetCoordinates();

            var chainedBombs = new CompositeBomb();

            var bombsDetonated = this.Field.Explode(new Cell(coordinates), this.ChainReactionEnabled, chainedBombs);

            if (this.ChainReactionEnabled)
            {
                this.ChainReactionEnabled = false;
                bombsDetonated += chainedBombs.ChainReact(this.Field);
            }

            return bombsDetonated;
        }
    }
}