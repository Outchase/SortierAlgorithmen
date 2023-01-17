using System;

namespace SortierAlgorithmen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool wantToSortAgain = true;
            int numberOfNumbers = 0;
            int minRange = 0;
            int maxRange = 0;

            ASCIISIGN sign = new();
            Tools tools = new();



            while (wantToSortAgain)
            {
                tools.PrintInColor(sign.title + "\n" + "Press Enter to Start\n", ConsoleColor.Yellow, true);
                tools.OnPressContinue(true);

                numberOfNumbers = tools.NumberVerifier("Please enter the amount of number you want to sort: ");
                minRange = tools.NumberVerifier("Please enter minimum Range: ");
                maxRange = tools.NumberVerifier("Please enter maximum Range: ");

                int[] array = new int[numberOfNumbers];


                //int[] array = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };

                tools.PutValueInArray(array, minRange, maxRange);

                tools.PrintArray(array);

                //array = tools.QuickSortArray(array, 0, array.Length - 1);

                array = tools.HeapSort(array, array.Length);

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
