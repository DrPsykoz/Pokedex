using Newtonsoft.Json;
using PokedexModels.Models;
using PokedexModels.Models.Pokemon;
using System;
using System.Collections.Generic;

namespace Pokedex.Models
{
    public class Pokemon
    {

        public static string URL_GET_ID = "https://pokeapi.co/api/v2/pokemon/";
        public static string URL_GET_NAME = "https://pokeapi.co/api/v2/pokemon/";

        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("types")]
        public List<SlotType> Types { get; set; }
        public PokemonDescription Description { get; set; }
        public PokemonEvolutionChain EvolutionChain { get; set; }
        [JsonProperty("species")]
        private NamedEmptyData SpeciesURL { get; set; }

        public string GetSpeciesURL() => SpeciesURL.Url;

        public override string ToString() => $"<{ID}> {Name}";
    }
}
