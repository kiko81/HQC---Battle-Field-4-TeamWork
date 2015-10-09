namespace Battlefield.Logic.OutputProviders
{
    using System;

    public static class ConsoleOutput
    {
        private const string WelcomeMessage = "Welcome to \"Battle Field\" game.\nEnter battle field size: ";
        private const string WinningMessage = "Game over! {0} WINS!!!\nNumber of shots made: {1}";
        private const string RoundSummaryMessage = "Mines detonated this round: {0}";

        public static void PrintWelcomeMessage()
        {
            Console.Write(WelcomeMessage);
        }

        public static void PrintWinningMessage(string name, int count)
        {
            Console.WriteLine(WinningMessage, name, count);
        }

        public static void PrintRoundSummary(int minesDetonated)
        {
            Console.WriteLine(RoundSummaryMessage, minesDetonated);
        }

        public static void Print(string str)
        {
            Console.WriteLine(str);
        }
    }
}
