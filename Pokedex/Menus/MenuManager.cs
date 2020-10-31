using Pokedex.Menus.Instances;
using Pokedex.Models;
using System;
using System.Collections.Generic;

namespace Pokedex.Menus
{
    class MenuManager
    {

        public static List<MenuKeyed> MENUS = new List<MenuKeyed>()
        {
            new MenuPrincipal(),
            new MenuListe<Pokemon>(PokemonManager.FACTORY, PokemonManager.URL_GET_ID),
            new MenuRecherche<Pokemon>(PokemonManager.FACTORY, PokemonManager.URL_GET_NAME)
        };

        public static MenuKeyed FromKey(ConsoleKey key)
        {
            foreach (MenuKeyed menu in MENUS)
                if (menu.AccessKey.Equals(key))
                    return menu;
            return null;
        }

        public static MenuKeyed FromType<T>()
        {
            foreach (MenuKeyed menu in MENUS)
                if (menu is T)
                    return menu;
            return null;
        }

    }
}
