using System;

namespace SortierAlgorithmen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool wantToSortAgain = true;
            ASCIISIGN sign = new();
            Tools tools = new();

            while (wantToSortAgain)
            {
                tools.PrintInColor(sign.title + "\n" + "Press Enter to Start\n", ConsoleColor.Yellow, true);
                tools.OnPressContinue(true);

                tools.PrintInColor("Please enter the amount of number you want to sort: ", ConsoleColor.Green, false);
                Console.ReadLine();

                Console.ReadKey();
                wantToSortAgain= false;
            }

            tools.PrintInColor(sign.outro, ConsoleColor.Yellow, true);

            Environment.Exit(0);
        }
    }
}
