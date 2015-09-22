namespace BattleField.InputProviders
{
    using System;

    using Common;

    public class ConsoleInput
    {
        public static int GetSizeInput()
        {
            int fieldSize;
            int.TryParse(Console.ReadLine(), out fieldSize);

            while (fieldSize < Constants.MinFieldSize || fieldSize > Constants.MaxFieldSize)
            {
                Console.Write("n is between 1 and 10! Please enter new n = ");
                int.TryParse(Console.ReadLine(), out fieldSize);
            }

            return fieldSize;
        }

        public static void GetTargetCoordinates(int size, out int x, out int y)
        {
            x = 0;
            y = 0;
            bool isValid = false;
            while (!isValid) //check input
            {
                Console.Write("Please enter coordinates X and Y separated by space: ");
                string input = Console.ReadLine();
                var coordinates = input.Split(' ');
                if (coordinates.Length == 2)
                {
                    x = int.Parse(coordinates[1]) - 1;
                    y = int.Parse(coordinates[0]) - 1;

                    if (x < 0 || x > size || y < 0 || y > size)
                        Console.WriteLine("Invalid move!");
                    else
                    {
                        isValid = true;
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
