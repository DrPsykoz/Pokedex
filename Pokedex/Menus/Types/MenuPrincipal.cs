using Pokedex.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pokedex.Menus
{
    class MenuPrincipal : MenuKeyed
    {
        int row = 1;

        public MenuPrincipal() : base("Menu Principal", ConsoleKey.Spacebar){}

        public override void run()
        {
            var size = from menu in MenuManager.MENUS
                       orderby menu.AccessKey.ToString().Length
                       select menu.AccessKey.ToString().Length;

            int keySize = size.Last() + 1;


            for(int i = 1; i < MenuManager.MENUS.Count; i++)
            {
                MenuKeyed menu = MenuManager.MENUS[i];

                int currentKeySize = menu.AccessKey.ToString().Length;
                string keyString = row == i ? " " + menu.AccessKey.ToString() : menu.AccessKey.ToString();

                ColorConsole.Write($" {keyString}", row == i ? ConsoleColor.Cyan : ConsoleColor.White);

                while (currentKeySize < keySize)
                {
                    Console.Write(" ");
                    currentKeySize++;
                }

                Console.WriteLine($"| {menu.Title}");
            }

            Console.WriteLine(" ");
            ColorConsole.WriteLine("─────────── COMMANDES ───────────", ConsoleColor.White);
            ColorConsole.WriteLine("  ↑   ", "Menu precedent", ConsoleColor.Yellow, ConsoleColor.White);
            ColorConsole.WriteLine("  ↓   ", "Menu suivant", ConsoleColor.Yellow, ConsoleColor.White);
            ColorConsole.WriteLine("ENTER ", "Acceder au menu selectionné", ConsoleColor.Yellow, ConsoleColor.White);
            ColorConsole.WriteLine("ECHAP ", "Quitter l'application", ConsoleColor.Yellow, ConsoleColor.White);

        }

        public override void applyKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (row > 1)
                        row--;
                    break;
                case ConsoleKey.DownArrow:
                    if (row < MenuManager.MENUS.Count - 1)
                        row++;
                    break;
                case ConsoleKey.Enter:
                    Pokedex.CURRENT_MENU = MenuManager.MENUS[row];
                    break;
            }
        }
    }
}
