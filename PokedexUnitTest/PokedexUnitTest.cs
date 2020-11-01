using Pokedex;
using Pokedex.Models;
using Pokedex.Utils;
using PokedexModels.Models;
using System;

namespace PokedexUnitTest
{
    class PokedexUnitTest
    {
        static void Main(string[] args)
        {


            //Pokemon pokemonFromID = PokemonManager.FromID(1);

            //Console.WriteLine(pokemonFromID);

            //Pokemon pokemonFromName = PokemonManager.FromName("bulbasaur");

            //Console.WriteLine(pokemonFromName);

            //ObjectDisplay<Pokemon>.displayObject(pokemonFromID);

            //Console.WriteLine(pokemonFromID.Species.url);

            DataFactory<PokemonEvolutionChain> FactoryEvolutionChain = new DataFactory<PokemonEvolutionChain>();

            PokemonEvolutionChain firstChain = FactoryEvolutionChain.GetData(PokemonEvolutionChain.URL_GET_ID + 140);

            Console.WriteLine(firstChain);

        }
    }
}
