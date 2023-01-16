using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorithmen
{
    internal class Tools
    {
        public void PrintInColor(string message, ConsoleColor color, bool resetColor)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            if (resetColor)
            {
                Console.ResetColor();
            }
        }

        //Listens to enter key press, if parameter is true it clears the console
        public void OnPressContinue(bool clearConsole)
        {
            ConsoleKeyInfo userKeyInput;
            bool keyPressedRight = false;

            while (!keyPressedRight)
            {

                userKeyInput = Console.ReadKey(true);

                if (userKeyInput.Key == ConsoleKey.Enter)
                {
                    keyPressedRight = true;
                }
            }

            if (clearConsole)
            {
                Console.Clear();
            }
        }

        //Listens to two key press and return value, if parameter is true it clears the console
        public bool OnPressYesOrNo(bool clearConsole)
        {
            ConsoleKeyInfo userKeyInput;
            bool keyPressedRight = false;
            bool isAYes = false;

            while (!keyPressedRight)
            {

                userKeyInput = Console.ReadKey(true);

                if (userKeyInput.Key == ConsoleKey.Y)
                {
                    keyPressedRight = true;
                    isAYes = true;
                }
                else if (userKeyInput.Key == ConsoleKey.N)
                {
                    keyPressedRight = true;
                }
            }
            if (clearConsole)
            {
                Console.Clear();
            }
            return isAYes;

        }

        //quicksort creates two empty arrays to hold elements less than the pivot value and elements greater than the pivot value and then recursively sort the sub arrays
        //notice: works on small data set
        public int[] QuickSortArray(int[] array, int startIndex, int endingIndex)
        {

            var i = startIndex;
            var j = endingIndex;
            var pivot = array[startIndex];

            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (startIndex < j)
                QuickSortArray(array, startIndex, j);
            if (i < endingIndex)
                QuickSortArray(array, i, endingIndex);
            return array;
        }


        // function to print array
        public void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        // function to put random values into array
        public int[] PutValueInArray(int [] array)
        {
            Random rnd = new Random();
            int Min = 0;
            int Max = 20;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(Min, Max);
            }
            return array;
        }
    }
}
