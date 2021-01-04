using Pokedex;
using Pokedex.Models;
using PokedexModels.Models;
using System;
using Xunit;

namespace PokedexTestUnit
{
    public class UnitTest1
    {
        [Fact]
        public void GetIDPokemonTest()
        {
            // Les données
            int pokemonID = 1;
            
            Pokemon bulbasaur = new Pokemon();
            bulbasaur.ID = pokemonID;

            //Assert.Equal(5, getPokemon.ID); // Test Incorrect

            // Vérification de la récupération du Pokemon avec son ID
            Pokemon getPokemon = PokemonManager.GetPokemon(pokemonID).Result;
            Assert.Equal(getPokemon.ID, bulbasaur.ID);

            // Récupération de l'ID du Pokémon
            int getPokemon_ID = PokemonManager.GetPokemon(pokemonID).Result.ID;
            Assert.Equal(getPokemon_ID, pokemonID);

            //Assert.Equal(5, getPokemon_ID); // Test Incorrect
        }
        
        [Fact]
        public void GetNamePokemonTest()
        {
            // Les données
            string pokemonName = "bulbasaur";

            Pokemon bulbasaur = new Pokemon();
            bulbasaur.Name = pokemonName;

            //Assert.Equal("tiplouf", getPokemon.Name); // Test Incorrect

            // Vérification de la récupération du Pokemon avec son Nom
            Pokemon getPokemon = PokemonManager.GetPokemon(pokemonName).Result;
            Assert.Equal(getPokemon.Name, bulbasaur.Name);

            // Récupération du nom du Pokémon
            string getPokemon_Nom = Convert.ToString(PokemonManager.GetPokemon(pokemonName).Result);
            Assert.Equal(pokemonName, pokemonName);

            //Assert.Equal("poussifeu", pokemonName); // Test Incorrect

        }

        [Fact]
        public void GetDataTest()
        {
            string pokemonName = "bulbasaur";
            int pokemonID = 1;

            // Test de l'URL
            string baseUrl = Pokemon.URL_GET_NAME;
            Assert.Equal("https://pokeapi.co/api/v2/pokemon/", baseUrl);
            //Assert.Equal("https://pokeapi.co/api/v2/pokedex/", baseUrl); // Test Incorrect

            Assert.Equal(Pokemon.URL_GET_ID, Pokemon.URL_GET_NAME);

            string finalUrl = baseUrl + pokemonName;
            Assert.Equal("https://pokeapi.co/api/v2/pokemon/bulbasaur", finalUrl);
            //Assert.Equal("https://pokeapi.co/api/v2/pokedex/bulbasaur", finalUrl); // Test Incorrect

            // Test de GetData avec l'URL
            DataFactory<Pokemon> factory = new DataFactory<Pokemon>();

            // On récupère un Pokémon avec GetData
            Pokemon pokemon = factory.GetData(finalUrl);
            Assert.Equal(pokemon.ID, pokemonID);
            Assert.Equal(pokemon.Name, pokemonName);
        }

        [Fact]
        public void EvolutionChainTest()
        {
            int pokemonID = 1;
            string pokemonName = "bulbasaur";

            // Récupération d'un Pokémon 
            Pokemon bulbasaur = PokemonManager.GetPokemon(pokemonID).Result;

            // Récupération d'un Pokémon avec les détails
            DataFactory<Pokemon> pokemonFactory = new DataFactory<Pokemon>();
            DataFactory<PokemonSpecies> pokemonSpecies = new DataFactory<PokemonSpecies>();
            DataFactory<PokemonEvolutionChain> evolutionFactory = new DataFactory<PokemonEvolutionChain>();

            Pokemon pokemonTest = pokemonFactory.GetData("https://pokeapi.co/api/v2/pokemon/bulbasaur");
            PokemonSpecies species = pokemonSpecies.GetData(pokemonTest.GetSpeciesURL());

            pokemonTest.EvolutionChain = evolutionFactory.GetData(species.GetEvolutionURL());

            // Test pour voir si nous avons bien les pokémons correspondant
            Assert.Equal(pokemonID, bulbasaur.ID);
            Assert.Equal(pokemonID, pokemonTest.ID);
            Assert.Equal(pokemonTest.ID, bulbasaur.ID);

            Assert.Equal(pokemonName, bulbasaur.Name);
            Assert.Equal(pokemonName, pokemonTest.Name);
            Assert.Equal(pokemonTest.Name, bulbasaur.Name);

            // Vérification que les deux Pokémons (pokémonTest & bulbasaur) possèdent la même chaine d'évolution
            Assert.Equal(pokemonTest.EvolutionChain, bulbasaur.EvolutionChain);
        }
    }
}
