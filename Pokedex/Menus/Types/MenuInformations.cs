using Pokedex.Utils;
using System;

namespace Pokedex.Menus.Instances
{
    class MenuInformations<T> : Menu
    {

        private T value;
        private Menu lastMenu;

        public MenuInformations(T value, Menu lastMenu) : base("Informations sur un " + typeof(T).Name)
        {
            this.value = value;
            this.lastMenu = lastMenu;
        }

        public override void run()
        {

            // Affichage des proprietes de l'objet
            ObjectDisplay<T>.displayObject(value);


            Console.WriteLine($"");
            ColorConsole.WriteLine("─────────── COMMANDES ───────────", ConsoleColor.White);
            ColorConsole.Write("SPACEBAR ", ConsoleColor.Yellow);
            ColorConsole.WriteLine($"Retourner sur le menu {lastMenu.Title}", ConsoleColor.White);
        }

        public override void applyKey(ConsoleKey key)
        {
            if (key.Equals(ConsoleKey.Spacebar))
            {
                Pokedex.CURRENT_MENU = lastMenu;
            }
        }

    }
}
