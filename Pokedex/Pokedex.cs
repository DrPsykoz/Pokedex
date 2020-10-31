using Pokedex.Menus;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Input;

namespace Pokedex
{
    class Pokedex
    {

        public static Menu CURRENT_MENU = MenuManager.MENUS[0];

        static void Main(string[] args)
        {

            ConsoleKeyInfo input;

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            do
            {
                CURRENT_MENU.display();
                input = Console.ReadKey();
                CURRENT_MENU.applyKey(input.Key);
            } while (!input.Key.Equals(ConsoleKey.Escape));

        }
    }
}
