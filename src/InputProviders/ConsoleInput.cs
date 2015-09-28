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
                Console.Write("Field size is between {0} and {1}! Please enter field size: ", Constants.MinFieldSize, Constants.MaxFieldSize);
                int.TryParse(Console.ReadLine(), out fieldSize);
            }

            return fieldSize;
        }

        public static void GetTargetCoordinates(int size, out int x, out int y)
        {
            x = 0;
            y = 0;
            bool isValidPosition = false;

            while (!isValidPosition) //check input
            {
                Console.Write("Please enter X and Y coordinates separated by space: ");
                string input = Console.ReadLine();
                var coordinates = input.Split(' ')
                    .Where(entry => !string.IsNullOrEmpty(entry))
                    .ToArray();

                if (coordinates.Length == 2)
                {
                    if (int.TryParse((coordinates[0]), out y))
                    {
                        y -= 1;
                    }
                    else
                    {
                        Console.WriteLine("Invalid X coordinate!");
                        continue;
                    }

                    if (int.TryParse((coordinates[1]), out x))
                    {
                        x -= 1;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Y coordinate!");
                        continue;
                    }
                    
                    bool xOutOfBounds = x < 0 || x >= size;
                    bool yOutOfBounds = y < 0 || y >= size;

                    if (xOutOfBounds || yOutOfBounds)
                    {
                        Console.WriteLine("Invalid move! Shot out of field");
                    }
                    else
                    {
                        isValidPosition = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move!");
                }
            }
        }
    }
}
