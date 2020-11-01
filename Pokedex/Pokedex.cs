using Pokedex.Menus;
using Pokedex.Models;
using System;

namespace Pokedex
{
    class Pokedex
    {

        public static Menu CURRENT_MENU = MenuManager.MENUS[0];
        public static DataFactory<Pokemon> FACTORY = new DataFactory<Pokemon>();

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
