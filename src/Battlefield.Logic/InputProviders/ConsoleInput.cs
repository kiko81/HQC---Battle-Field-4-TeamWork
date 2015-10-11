namespace Battlefield.Logic.InputProviders
{
    using System;

    using Battlefield.Logic.Common;

    public class ConsoleInput : IInput
    {
        private readonly int fieldsize;

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
                Console.Write("Field size must be between {0} and {1}! Please enter valid field size: ", Constants.MinFieldSize, Constants.MaxFieldSize);

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
                Console.Write("Please enter X and Y coordinates (e.g. a1): ");
                var input = Console.ReadLine().Trim();

                if (input.Length == 2 || input.Length == 3)
                {
                    var xCoordinate = char.ToUpper(input[0]);
                    if (char.IsLetter(xCoordinate))
                    {
                        row = xCoordinate - 'A';
                    }
                    else
                    {
                        Console.WriteLine("Invalid X coordinate!");
                        continue;
                    }

                    if (int.TryParse(input.Substring(1), out col))
                    {
                        col -= 1;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Y coordinate!");
                        continue;
                    }
                    
                    if (Validators.IsInBounds(row, this.fieldsize) && Validators.IsInBounds(col, this.fieldsize))
                    {
                        return new Coordinates(row, col);
                    }

                    Console.WriteLine("Invalid target! Shot out of bounds");
                }
                else
                {
                    Console.WriteLine("Invalid target!");
                }
            }
        }

        public string GetNameInput(string player)
        {
            Console.Write("Please enter {0} player name: ", player);
            var input = Console.ReadLine();
           
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("Please enter some name for {0} player: ", player);
                input = Console.ReadLine();
            }

            return input;
        }
    }
}