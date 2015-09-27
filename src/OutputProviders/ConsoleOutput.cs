namespace BattleField.OutputProviders
{
    using System;
    using System.Text;

    using Common;

    public static class ConsoleOutput
    {
        public static void WelcomeMessage()
        {
            Console.Write("Welcome to \"Battle Field\" game.\nEnter battle field size: ");
        }

        public static void WinningMessage(int numberOfShots)
        {
            Console.WriteLine("Game over! Number of shots made:{0}", numberOfShots);
        }

        public static void Print(string str)
        {
            Console.WriteLine(str);
        }
    }
}
