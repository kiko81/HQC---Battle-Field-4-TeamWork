<<<<<<< HEAD
﻿namespace BattleField.Players
{
    using System;

    using Fields;
    using GameObjects;
    using InputProviders;

    public class Player
    {
        //leave it public for future testing
        public const string StringCannotBeNullOrEmpty = "Name cannot be null or empty!";
=======
﻿namespace Battlefield.Logic.Players
{
    using Contracts;

    using Fields;

    using GameObjects;

    public class Player
    {
>>>>>>> cfeb289ed63a3d0338c07bd56be7b30bb5f7b32c
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
<<<<<<< HEAD
            
            private set 
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new NullReferenceException(StringCannotBeNullOrEmpty);
                }

                this.name = value; 
            }
=======
            // validate name
            private set { this.name = value; }
>>>>>>> cfeb289ed63a3d0338c07bd56be7b30bb5f7b32c
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