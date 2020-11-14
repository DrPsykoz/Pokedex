using Pokedex.Menus.Instances;
using Pokedex.Models;

namespace Pokedex.Menus
{
    public class MenuPokemonListe : MenuListe<Pokemon>
    {
        public override Pokemon GetData(int index) => PokemonManager.GetPokemon(index).Result;
    }
}
