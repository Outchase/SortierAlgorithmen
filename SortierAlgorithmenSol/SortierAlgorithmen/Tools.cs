using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public bool OnPressYesOrNo(bool clearConsole, string message)
        {
            PrintInColor(message, ConsoleColor.Green, true);

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

        public int OnChoice(bool clearConsole, string message, string[] array)
        {
           
            //int userInput = 0;
            int result = 0;
            bool keyPressedRight = false;

            while (!keyPressedRight)
            {
                Console.Clear();
                PrintInColor(message, ConsoleColor.Green, true);
                PrintStringArray(array);

                int.TryParse(Console.ReadLine(), out result);

                if (result > 0 && result < array.Length + 1)
                {
                    keyPressedRight = true;
                }
            }

            if (clearConsole)
            {
                Console.Clear();
            }

            return result;

        }

        //quicksort creates two empty arrays to hold elements less than the pivot value and elements greater than the pivot value and then recursively sort the sub arrays
        //notice: works on small data set else not stable
        public int[] QuickSortArray(int[] array, int startIndex, int endingIndex)
        {
            //assigning the values to variables
            var i = startIndex;
            var j = endingIndex;
            //set the array's pivot to the left
            var pivot = array[startIndex];

            while (i <= j)
            {
                //starts placing the pivot element at its correct position in the sorted array by dividing the array into two lists
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }

                //if the left subarray element (item from left) is greater than the pivot and the right subarray element (item from right) is smaller than the pivot
                //swap their positions
                if (i <= j)
                {
                    //the value is saved in a temporary variable
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            //calls itself to sort the left and right subarrays
            if (startIndex < j)
            {
                QuickSortArray(array, startIndex, j);
            }

            if (i < endingIndex)
            {
                QuickSortArray(array, i, endingIndex);
            }
            return array;
        }

        //heapsort creates max heap, remove the largest item and puts into a sorted partition
        //notice: used when the smallest or highest value is needed instantly
        public int[] HeapSort(int[] array, int size)
        {
            //checking if array is empty
            if (size <= 1)
            {
                return array;
            }

            //calls Heapify() to build the max heap
            for (int i = size / 2 - 1; i >= 0; i--)
            {
                Heapify(array, size, i);
            }

            //swap the last element of the max heap with the first element
            for (int i = size - 1; i >= 0; i--)
            {
                var tempVar = array[0];
                array[0] = array[i];
                array[i] = tempVar;

                //rebuild the max heap
                Heapify(array, i, 0);
            }

            //return sorted array
            return array;
        }

        //convert the heap into a max heap
        public void Heapify(int[] array, int size, int index)
        {
            //set the largest index element to the current index
            var largestIndex = index;

            var leftChildItem = 2 * index + 1;
            var rightChildItem = 2 * index + 2;

            //if left child item is greater than current root element
            //swap positions
            if (leftChildItem < size && array[leftChildItem] > array[largestIndex])
            {
                largestIndex = leftChildItem;
            }

            //if right child item is greater than current root element
            //swap positions
            if (rightChildItem < size && array[rightChildItem] > array[largestIndex])
            {
                largestIndex = rightChildItem;
            }

            //if index of maximum element in array is not equal to current index
            //swap positions of array[largestIndex] with array[index]
            if (largestIndex != index)
            {
                var tempVar = array[index];
                array[index] = array[largestIndex];
                array[largestIndex] = tempVar;

                //recursively call the function until the max heap is build
                Heapify(array, size, largestIndex);
            }
        }

        //Mergesort works with divide & conquer
        //Divide: starts dividing teh array into two halves until there are no half-arrays to divide
        public int[] MergeSort(int[] array, int leftInt, int rightInt)
        {
            //checking if array has a range
            if (leftInt < rightInt)
            {

                //Use left and right integer values to specify the index of the array's middle
                int middlePoint = leftInt + (rightInt - leftInt) / 2;

                //recursively calls itself to subdivide the right and left subarrays
                MergeSort(array, leftInt, middlePoint);
                MergeSort(array, middlePoint + 1, rightInt);

                //Calls the merging method after each array contains one element
                MergeArray(array, leftInt, middlePoint, rightInt);
            }

            return array;
        }

        //Conquer: sorts and merges the sub-arrays
        public void MergeArray(int[] array, int left, int middle, int right)
        {
            //Helps to define temporary arrays
            var leftArrayLength = middle - left + 1;
            var rightArrayLength = right - middle;

            //Create temporary arrays to hold values during sorting
            var leftTempArray = new int[leftArrayLength];
            var rightTempArray = new int[rightArrayLength];
            int i;
            int j;

            //Using two loops to copy data into the temporary arrays
            for (i = 0; i < leftArrayLength; ++i)
            {
                leftTempArray[i] = array[left + i];
            }

            for (j = 0; j < rightArrayLength; ++j)
            {
                rightTempArray[j] = array[middle + 1 + j];
            }

            i = 0;
            j = 0;
            int k = left;

            //compare the elements in the left and right temporary array
            while (i < leftArrayLength && j < rightArrayLength)
            {
                //if left temporary array is less or equal to the right temporary array element
                //then swap position while sorting them into array[k]
                if (leftTempArray[i] <= rightTempArray[j])
                {
                    array[k++] = leftTempArray[i++];
                }
                else
                {
                    array[k++] = rightTempArray[j++];
                }
            }

            //Copying any remaining elements from the left and right temporary array into the merged array
            while (i < leftArrayLength)
            {
                array[k++] = leftTempArray[i++];
            }

            while (j < rightArrayLength)
            {
                array[k++] = rightTempArray[j++];
            }
        }

        // function to print array
        public void PrintIntArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        public void PrintStringArray(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(i+1 +". "+array[i] + "\n");
            }
            Console.WriteLine();
        }

        // function to put random values into array
        public int[] PutValueInArray(int[] array, int minValue, int maxValue)
        {
            Random rnd = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(minValue, maxValue);
            }
            return array;
        }

        public int NumberVerifier(string promptMessage)
        {
            bool isNumber = false;
            int result = 0;

            while (!isNumber)
            {
                PrintInColor(promptMessage, ConsoleColor.Green, false);
                isNumber = int.TryParse(Console.ReadLine(), out result);
                Console.Clear();
            }

            return result;
        }
    }
}
