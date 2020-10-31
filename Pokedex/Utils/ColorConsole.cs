using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Utils
{
    class ColorConsole
    {

        public static void WriteLine(string text, ConsoleColor color)
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = old;
        }
        public static void WriteLine(string text, string text2, ConsoleColor color, ConsoleColor color2)
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = color2;
            Console.WriteLine(text2);
            Console.ForegroundColor = old;
        }


        public static void Write(string text, ConsoleColor color)
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = old;
        }

    }
}
