namespace BattleField.InputProviders
{
    using System;

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

        public static void GetTargetCoordinates(int size, out int col, out int row)
        {
            col = 0;
            row = 0;
            var isValidPosition = false;

            while (!isValidPosition) 
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
                    
                    var rowOutOfBounds = col < 0 || size <= col;
                    var colOutOfBounds = row < 0 || size <= row;

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
