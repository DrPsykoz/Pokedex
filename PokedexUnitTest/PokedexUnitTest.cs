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

            /*
             *      Pokemons
             */

            Console.WriteLine("───────────────────────────────────────────────────────");
            Console.WriteLine("Lancement des tests pour les Pokemons");
            Console.WriteLine("───────────────────────────────────────────────────────");

            DataFactory<Pokemon> FactoryPokemon = new DataFactory<Pokemon>();



            Console.WriteLine("\n → Recuperation d'un pokemon via son ID (id = 1)");

            Pokemon pokemonFromID = FactoryPokemon.GetData(Pokemon.URL_GET_ID + 1);

            displayTestExecution(pokemonFromID != default);
            Console.WriteLine("   Donnée récupérée: " + pokemonFromID);



            Console.WriteLine("\n → Recuperation d'un pokemon via son Nom (name = bulbasaur)");

            Pokemon pokemonFromName = FactoryPokemon.GetData(Pokemon.URL_GET_NAME + "bulbasaur");

            displayTestExecution(pokemonFromName != default);
            Console.WriteLine("   Donnée récupérée: " + pokemonFromName);



            Console.WriteLine("\n → Affichage des données d'un pokemon via réflection (pokemon = bulbasaur)");

            ObjectDisplay<Pokemon>.displayObject(pokemonFromID);


            /*
             *      Chaines d'evolutions
             */

            Console.WriteLine("\n\n───────────────────────────────────────────────────────");
            Console.WriteLine("Lancement des tests pour les Chaines D'evolution");
            Console.WriteLine("───────────────────────────────────────────────────────");

            DataFactory<PokemonEvolutionChain> FactoryEvolutionChain = new DataFactory<PokemonEvolutionChain>();

            Console.WriteLine("\n → Recuperation d'une chaine d'evolution via son ID (id = 140)");

            PokemonEvolutionChain firstChain = FactoryEvolutionChain.GetData(PokemonEvolutionChain.URL_GET_ID + 140);

            displayTestExecution(firstChain != default);
            Console.WriteLine("   Donnée récupérée: " + firstChain);

        }

        public static void displayTestExecution(bool success)
        {
            if (success)
                ColorConsole.WriteLine("   TEST REUSSI", ConsoleColor.Green);
            else
                ColorConsole.WriteLine("   TEST ECHOUÉ", ConsoleColor.Red);
        }
    }
}
