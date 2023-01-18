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
            int userSelect = 0;
            string[] algorythName = new string[3] { "QuickSort", "HeapSort", "MergeSort" };

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
                tools.PutValueInArray(array, minRange, maxRange);


                //Display Algorythm choices
                userSelect =tools.OnChoice(true,"Select your sorting algorithm:\n", algorythName);
            
                tools.PrintInColor("Unsorted Array:\n", ConsoleColor.Green, true);
                tools.PrintIntArray(array);

                if (userSelect > 2)
                {
                    tools.PrintInColor("\nMergeSort:\n", ConsoleColor.Blue, true);
                    array = tools.MergeSort(array, 0, array.Length - 1);
                }
                else if (userSelect > 1)
                {
                    tools.PrintInColor("\nHeapSort:\n", ConsoleColor.Blue, true);
                    array = tools.HeapSort(array, array.Length);
                }
                else {
                    tools.PrintInColor("\nQuickSort:\n", ConsoleColor.Blue, true);
                    array = tools.QuickSortArray(array, 0, array.Length - 1);
                }

                tools.PrintIntArray(array);
                wantToSortAgain = tools.OnPressYesOrNo(true, "\nDo you want to sort again ? [Y/n] ");
            }

            tools.PrintInColor(sign.outro, ConsoleColor.Yellow, true);
            Environment.Exit(0);
        }
    }
}
