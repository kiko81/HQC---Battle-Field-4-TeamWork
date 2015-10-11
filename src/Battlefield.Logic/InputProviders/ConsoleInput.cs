namespace Battlefield.Logic.InputProviders
{
    using System;

    using Battlefield.Logic.Common;

    public class ConsoleInput : IInput
    {
        private readonly int fieldsize;

        private const string FieldSizeConstraints = "Field size must be between {0} and {1}! Please enter valid field size: ";
        private const string EnterXAndY = "Please enter X and Y coordinates (e.g. a1): ";
        private const string InvalidX = "Invalid X coordinate!";
        private const string InvalidY = "Invalid Y coordinate!";
        private const string TargetOutOfBounds = "Invalid target! Shot out of bounds";
        private const string InvalidTarget = "Invalid target!";
        private const string EnterPlayerNameMessage = "Please enter {0} player name: ";

        public ConsoleInput(int size)
        {
            this.fieldsize = size;
        }

        public static int GetSizeInput()
        {
            int fieldSize;
            int.TryParse(Console.ReadLine(), out fieldSize);

            while (fieldSize < Constants.MinFieldSize || fieldSize > Constants.MaxFieldSize)
            {
                Console.Write(FieldSizeConstraints, Constants.MinFieldSize, Constants.MaxFieldSize);

                int.TryParse(Console.ReadLine(), out fieldSize);
            }

            return fieldSize;
        }

        public Coordinates GetTargetCoordinates()
        {
            int col;
            int row;

            while (true) 
            {
                Console.Write(EnterXAndY);
                var input = Console.ReadLine().Trim();

                if (input.Length == 2 || input.Length == 3)
                {
                    var xCoordinate = char.ToUpper(input[0]);
                    if (char.IsLetter(xCoordinate))
                    {
                        col = xCoordinate - 'A';
                    }
                    else
                    {
                        Console.WriteLine(InvalidX);
                        continue;
                    }

                    if (int.TryParse(input.Substring(1), out row))
                    {
                        row -= 1;
                    }
                    else
                    {
                        Console.WriteLine(InvalidY);
                        continue;
                    }
                    
                    if (Validators.IsInBounds(row, this.fieldsize) && Validators.IsInBounds(col, this.fieldsize))
                    {
                        return new Coordinates(row, col);
                    }

                    Console.WriteLine(TargetOutOfBounds);
                }
                else
                {
                    Console.WriteLine(InvalidTarget);
                }
            }
        }

        public string GetNameInput(string player)
        {
            Console.Write(EnterPlayerNameMessage, player);
            var input = Console.ReadLine();
           
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write(EnterPlayerNameMessage, player);
                input = Console.ReadLine();
            }

            return input;
        }
    }
}