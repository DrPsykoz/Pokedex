using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Menus
{
    abstract class MenuKeyed : Menu
    {
        public ConsoleKey AccessKey { get; }

        public MenuKeyed(string title, ConsoleKey accessKey) : base(title)
        {
            this.AccessKey = accessKey;
        }

    }
}
