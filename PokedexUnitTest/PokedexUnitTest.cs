using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pokedex;
using Pokedex.Models;
using Pokedex.Utils;
using PokedexModels.Models;
using System;
using System.Collections.Generic;
using Xunit;

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


            Console.WriteLine("\n → Recuperation d'un pokemon via son ID (id = 1)");

            Pokemon pokemonFromID = PokemonManager.GetPokemon(1).Result;

            displayTestExecution(pokemonFromID != default);
            Console.WriteLine("   Donnée récupérée: " + pokemonFromID);



            Console.WriteLine("\n → Recuperation d'un pokemon via son Nom (name = bulbasaur)");

            Pokemon pokemonFromName = PokemonManager.GetPokemon("bulbasaur").Result;

            displayTestExecution(pokemonFromName != default);
            Console.WriteLine("   Donnée récupérée: " + pokemonFromName);



            Console.WriteLine("\n → Recuperation d'un pokemon en entier via son ID et affichage via réflection (pokemon = bulbasaur)");

            Pokemon pokemonFull = PokemonManager.GetPokemon(1).Result;

            displayTestExecution(pokemonFull != default);
            Console.WriteLine("   Donnée récupérée: \n");
            ObjectDisplay<Pokemon>.displayObject(pokemonFull);


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
