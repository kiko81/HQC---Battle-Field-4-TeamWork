﻿namespace Battlefield.Logic.OutputProviders
{
    using System;

    public static class ConsoleOutput
    {
        public static void WelcomeMessage()
        {
            Console.Write("Welcome to \"Battle Field\" game.\nEnter battle field size: ");
        }

        public static void WinningMessage(string name, int count)
        {
            Console.WriteLine("Game over! {0} WINS!!!\nNumber of shots made: {1}", name, count);
        }

        public static void PrintRoundSummary(int minesDetonated)
        {
            Console.WriteLine("Mines detonated this round: {0}", minesDetonated);
        }

        public static void Print(string str)
        {
            Console.WriteLine(str);
        }
    }
}
