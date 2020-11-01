using Pokedex.Menus.Instances;
using Pokedex.Models;
using PokedexModels.Models;
using System.Collections.Generic;

namespace Pokedex.Menus
{
    class MenuManager
    {

        public static List<Menu> MENUS = new List<Menu>()
        {
            new MenuPrincipal(),
            new MenuListe<Pokemon>(PokemonManager.FACTORY, Pokemon.URL_GET_ID),
            new MenuListe<PokemonEvolutionChain>(new DataFactory<PokemonEvolutionChain>(), PokemonEvolutionChain.URL_GET_ID),
            new MenuRecherche<Pokemon>(PokemonManager.FACTORY, Pokemon.URL_GET_NAME)
        };

        public static Menu FromType<T>()
        {
            foreach (Menu menu in MENUS)
                if (menu is T)
                    return menu;
            return null;
        }

    }
}
