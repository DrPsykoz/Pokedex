using Newtonsoft.Json;
using System;

namespace PokedexModels.Models.Pokemon
{
    public class PokemonDescription
    {
        private string description;
        [JsonProperty("flavor_text")]
        public string Description { 
            get { return description; }
            set { description = value.Replace('\n', ' '); } 
        }
        [JsonProperty("language")]
        public Language Language { get; set; }

        public override string ToString() => $"{Description}";

    }
}
