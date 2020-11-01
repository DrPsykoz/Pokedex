using Newtonsoft.Json;
using PokedexModels.Models;
using System;
using System.Collections.Generic;

namespace Pokedex.Models
{
    public class Pokemon
    {

        public static string URL_GET_ID = "https://pokeapi.co/api/v2/pokemon/";
        public static string URL_GET_NAME = "https://pokeapi.co/api/v2/pokemon/";

        [JsonProperty("id")]
        public int ID { get; }
        [JsonProperty("name")]
        public string Name { get; }
        [JsonProperty("weight")]
        public int Weight { get; }
        [JsonProperty("height")]
        public int Height { get; }
        [JsonProperty("types")]
        public List<SlotType> Types { get; set; }
        [JsonProperty("species")]
        public PokemonSpecies Species { get; set; }

        public Pokemon(int id, string name, int weight, int height)
        {
            this.ID = id;
            this.Name = name;
            this.Weight = weight;
            this.Height = height;
        }


        public override string ToString()
        {
            return $"<{ID}> {Name}";
        }
    }
}
