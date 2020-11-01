using Pokedex.Utils;
using System;

namespace Pokedex.Menus
{
    abstract class Menu
    {
        protected bool NeedToBeRefreshed { get; set; }
        protected bool IsDisplaying { get; set; }

        public string Title { get; }

        public Menu(string title)
        {
            this.Title = title;
            this.NeedToBeRefreshed = false;
        }

        public abstract void Run();
        public abstract void ApplyKey(ConsoleKey key);

        public void RequestRefresh()
        {
            if (IsDisplaying)
                this.NeedToBeRefreshed = true;
            else if (Pokedex.CURRENT_MENU.Equals(this))
                Display();
        }

        public void Display()
        {
            if (IsDisplaying) return;
            IsDisplaying = true;
            NeedToBeRefreshed = false;
            Console.Clear();
            ColorConsole.Write("[POKE", "DEX]   ", ConsoleColor.Red, ConsoleColor.White);
            ColorConsole.WriteLine(Title, ConsoleColor.Yellow);
            ColorConsole.WriteLine("─────────────────────────────────", ConsoleColor.White);
            Console.WriteLine(" ");
            Run();
            IsDisplaying = false;

            if (NeedToBeRefreshed)
                Display();
                
        }

    }
}
