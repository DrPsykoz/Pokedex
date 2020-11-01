using Pokedex.Utils;
using System;

namespace Pokedex.Menus
{
    class MenuPrincipal : Menu
    {
        int row = 1;

        public MenuPrincipal() : base("Menu Principal") { }

        public override void run()
        {

            for (int i = 1; i < MenuManager.MENUS.Count; i++)
            {
                Menu menu = MenuManager.MENUS[i];
                ColorConsole.WriteLine(new string(' ', row == i ? 2 : 1) + $" {menu.Title}", row == i ? ConsoleColor.Cyan : ConsoleColor.White);
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
