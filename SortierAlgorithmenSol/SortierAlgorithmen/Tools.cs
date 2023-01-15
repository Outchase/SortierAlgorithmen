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

    }
}
