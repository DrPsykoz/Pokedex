using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pokedex.Models;

namespace Pokedex
{
    public class PokemonManager
    {

        public static DataFactory<Pokemon> FACTORY = new DataFactory<Pokemon>();

        public static string URL_GET_ID = "https://pokeapi.co/api/v2/pokemon/";
        public static string URL_GET_NAME = "https://pokeapi.co/api/v2/pokemon/";

        public static List<Pokemon> GetPokemons() { return FACTORY.GetCachedData(); }

        public static Pokemon FromID(int id) { return FACTORY.GetData(URL_GET_ID + id); }

        public static Pokemon FromName(string name) { return FACTORY.GetData(URL_GET_NAME + name.ToLower()); }

    }
}
