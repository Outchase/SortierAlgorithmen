using System;

namespace SortierAlgorithmen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool wantToSortAgain = true;
            bool isNumber = false;
            int numberOfNumbers = 0;
            ASCIISIGN sign = new();
            Tools tools = new();


            while (wantToSortAgain)
            {
                tools.PrintInColor(sign.title + "\n" + "Press Enter to Start\n", ConsoleColor.Yellow, true);
                tools.OnPressContinue(true);

                while(!isNumber)
                {
                    tools.PrintInColor("Please enter the amount of number you want to sort: ", ConsoleColor.Green, false);
                    isNumber = int.TryParse(Console.ReadLine(), out numberOfNumbers);
                }



                Console.WriteLine(isNumber);
                Console.WriteLine(numberOfNumbers);

                Console.ReadKey();
                wantToSortAgain= false;
            }

            tools.PrintInColor(sign.outro, ConsoleColor.Yellow, true);

            Environment.Exit(0);
        }
    }
}
