namespace BattleField.InputProviders
{
    using System;
    using System.Linq;

    using Common;

    public static class ConsoleInput
    {
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

        public static void GetTargetCoordinates(int size, out int x, out int y)
        {
            x = 0;
            y = 0;
            bool isValidPosition = false;

            while (!isValidPosition) 
            {
                Console.Write("Please enter X and Y coordinates separated by space: ");
                string input = Console.ReadLine();
                var coordinates = input.Split(' ')
                    .Where(entry => !string.IsNullOrEmpty(entry))
                    .ToArray();

                if (coordinates.Length == 2)
                {
                    var xCoordinate = coordinates[0].ToUpper()[0];
                    if (coordinates[0].Length == 1 && Char.IsLetter(xCoordinate))
                    {
                        y = xCoordinate - 'A';
                    }
                    else
                    {
                        Console.WriteLine("Invalid X coordinate!");
                        continue;
                    }

                    if (int.TryParse(coordinates[1], out x))
                    {
                        x -= 1;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Y coordinate!");
                        continue;
                    }
                    
                    bool rowOutOfBounds = x < 0 || size <= x;
                    bool colOutOfBounds = y < 0 || size <= y;

                    if (rowOutOfBounds || colOutOfBounds)
                    {
                        Console.WriteLine("Invalid target! Shot out of bounds");
                    }
                    else
                    {
                        isValidPosition = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid target!");
                }
            }
        }

        public static string GetNameInput(string player)
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
