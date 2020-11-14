using Newtonsoft.Json;
using PokedexModels.Models.Pokemon;
using System.Linq;

namespace PokedexModels.Models
{ 
    public class PokemonSpecies
    {
        [JsonProperty("flavor_text_entries")]
        public PokemonDescription[] Descriptions { get; set; }
        [JsonProperty("evolution_chain")]
        private NamedEmptyData EvolutionURL { get; set; }

        public string GetEvolutionURL() => EvolutionURL.Url;

        public PokemonDescription GetDescription(string lang) => Descriptions.Where(x => x.Language.Name.Equals(lang)).First();

    }

}
