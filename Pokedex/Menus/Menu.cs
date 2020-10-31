using Pokedex.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Menus
{
    abstract class Menu
    {
        private Boolean NeedToBeRefreshed { get; set; }
        private Boolean IsDisplaying { get; set; }

        public string Title { get; }

        public Menu(string title)
        {
            this.Title = title;
            this.NeedToBeRefreshed = false;
        }

        public abstract void run();
        public abstract void applyKey(ConsoleKey key);

        public void RequestRefresh()
        {
            if (IsDisplaying)
                this.NeedToBeRefreshed = true;
            else if (Pokedex.CURRENT_MENU.Equals(this))
                display();
        }

        public void display()
        {
            IsDisplaying = true;
            NeedToBeRefreshed = false;
            Console.Clear();
            ColorConsole.Write("[POKE", ConsoleColor.Red);
            ColorConsole.Write("DEX]   ", ConsoleColor.White);
            ColorConsole.WriteLine(Title, ConsoleColor.Yellow);
            ColorConsole.WriteLine("─────────────────────────────────", ConsoleColor.White);
            Console.WriteLine(" ");
            run();
            IsDisplaying = false;
            if (NeedToBeRefreshed)
                display();
        }

    }
}
