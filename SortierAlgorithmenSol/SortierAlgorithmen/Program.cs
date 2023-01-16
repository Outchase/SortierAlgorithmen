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

                while (!isNumber)
                {
                    tools.PrintInColor("Please enter the amount of number you want to sort: ", ConsoleColor.Green, false);
                    isNumber = int.TryParse(Console.ReadLine(), out numberOfNumbers);
                }

                int[] array = new int[numberOfNumbers];

                //int[] array = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };

                tools.PutValueInArray(array);

                tools.PrintArray(array);

                array = tools.QuickSortArray(array, 0, array.Length-1);

                tools.PrintArray(array);


                //Console.WriteLine(isNumber);
                //Console.WriteLine(numberOfNumbers);

                Console.ReadKey();
                wantToSortAgain = false;
            }
            Console.Clear();


            tools.PrintInColor(sign.outro, ConsoleColor.Yellow, true);

            Environment.Exit(0);
        }
    }
}
