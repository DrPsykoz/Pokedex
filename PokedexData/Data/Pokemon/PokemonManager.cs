using Pokedex.Models;
using System.Collections.Generic;

namespace Pokedex
{
    public class PokemonManager
    {

        public static DataFactory<Pokemon> FACTORY = new DataFactory<Pokemon>();



        public static List<Pokemon> GetPokemons() { return FACTORY.GetCachedData(); }

        //public static Pokemon FromID(int id) { return FACTORY.GetData(URL_GET_ID + id); }

        //public static Pokemon FromName(string name) { return FACTORY.GetData(URL_GET_NAME + name.ToLower()); }

    }
}
