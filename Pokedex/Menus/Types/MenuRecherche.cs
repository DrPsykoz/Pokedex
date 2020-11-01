using Pokedex.Utils;
using System;

namespace Pokedex.Menus.Instances
{
    class MenuRecherche<T> : Menu
    {

        private string input;
        private Boolean isSearching = false;
        private T item = default;

        private DataFactory<T> Factory;
        private string BaseUrl;

        public MenuRecherche(DataFactory<T> factory, string baseUrl) : base("Rechercher un " + typeof(T).Name)
        {
            this.Factory = factory;
            this.BaseUrl = baseUrl;
        }

        public override void applyKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Enter:
                    if (!Equals(item, default(T)))
                    {
                        Pokedex.CURRENT_MENU = new MenuInformations<T>(item, this);
                        isSearching = false;
                        input = "";
                        item = default;
                    }
                    else if (isSearching && Equals(item, default(T)))
                    {
                        isSearching = false;
                        input = "";
                        item = default;
                    }
                    else
                    {
                        isSearching = true;
                        item = Factory.GetData(BaseUrl + input.ToLower());
                    }
                    break;
                case ConsoleKey.Spacebar:
                    Pokedex.CURRENT_MENU = MenuManager.FromType<MenuPrincipal>();
                    break;
                case ConsoleKey.Backspace:
                    if (input.Length > 0)
                        input = input.Substring(0, input.Length - 1);
                    break;
                default:
                    input += key.ToString();
                    break;
            }

        }

        public override void run()
        {
            if (isSearching)
            {
                ColorConsole.WriteLine($"Resulat de la recherche pour: ", input, ConsoleColor.White, ConsoleColor.Yellow);
                Console.WriteLine("");
                if (item != null)
                    Console.WriteLine("     " + item);
                else
                    ColorConsole.WriteLine($"     {typeof(T).Name} inconnu. merci d'essayer avec un autre nom.", ConsoleColor.Red);

                Console.WriteLine(" ");
                ColorConsole.WriteLine("─────────── COMMANDES ───────────", ConsoleColor.White);
                if (item != null)
                    ColorConsole.WriteLine("ENTER    ", "Acceder aux details du " + typeof(T).Name, ConsoleColor.Yellow, ConsoleColor.White);
                else
                    ColorConsole.WriteLine("ENTER    ", "Modifier le nom a rechercher", ConsoleColor.Yellow, ConsoleColor.White);
                ColorConsole.WriteLine("SPACEBAR ", "Retour au menu principal", ConsoleColor.Yellow, ConsoleColor.White);
            }
            else
            {
                ColorConsole.WriteLine($"Quel est le nom du {typeof(T).Name} a rechercher ?", ConsoleColor.White);
                Console.WriteLine("");
                ColorConsole.WriteLine($"   {input}|", ConsoleColor.Yellow);

                Console.WriteLine(" ");
                ColorConsole.WriteLine("─────────── COMMANDES ───────────", ConsoleColor.White);
                ColorConsole.WriteLine("ENTER    ", "Rechercher le pokemon", ConsoleColor.Yellow, ConsoleColor.White);
                ColorConsole.WriteLine("SPACEBAR ", "Retour au menu principal", ConsoleColor.Yellow, ConsoleColor.White);
            }

        }
    }
}
