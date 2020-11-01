using Newtonsoft.Json;

namespace PokedexModels.Models
{
    public class EvolutionChain
    {
        [JsonProperty("species")]
        public NamedEmptyData SpeciesName { get; set; }

        [JsonProperty("evolves_to")]
        public EvolutionChain[] Evolutions { get; set; }

        private string Arrow => Evolutions.Length == 0 ? "" : " → ";

        public override string ToString() {
            return $"{SpeciesName.Name}{Arrow}{string.Join<EvolutionChain>(" or ", Evolutions)}";
        }

    }
}
