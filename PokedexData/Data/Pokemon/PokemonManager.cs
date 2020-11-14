using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Pokedex.Models;
using PokedexModels.Models;

namespace Pokedex
{
    public class PokemonManager
    {

        public static DataFactory<Pokemon> FACTORY = new DataFactory<Pokemon>();
        public static DataFactory<PokemonSpecies> SPECIES_FACTORY = new DataFactory<PokemonSpecies>();
        public static DataFactory<PokemonEvolutionChain> EVOLUTIONS_FACTORY = new DataFactory<PokemonEvolutionChain>();

       public static Task<Pokemon> GetPokemon(int id)
        {
            return Task.Run(() => CompletePokemon(FACTORY.GetData(Pokemon.URL_GET_ID + id)));
        }

        public static Task<Pokemon> GetPokemon(string name)
        {
            return Task.Run(() => CompletePokemon(FACTORY.GetData(Pokemon.URL_GET_NAME + name)));
        }

        public static Task<Pokemon[]> GetPokemonList(string[] urls)
        {
            return Task.Run(() => {
                return FACTORY.GetDataList(urls).ContinueWith(x =>
                {
                    Pokemon[] pokemons = x.Result;
                    foreach (Pokemon pokemon in pokemons)
                        CompletePokemon(pokemon);
                    return pokemons;
                });
            });
        }


        private static Pokemon CompletePokemon(Pokemon pokemon)
        {
            if (Object.Equals(pokemon, default)) return default;
            PokemonSpecies species = SPECIES_FACTORY.GetData(pokemon.GetSpeciesURL());
            pokemon.Description = species.GetDescription("en");
            pokemon.EvolutionChain = EVOLUTIONS_FACTORY.GetData(species.GetEvolutionURL());
            return pokemon;
        }

    }
}
