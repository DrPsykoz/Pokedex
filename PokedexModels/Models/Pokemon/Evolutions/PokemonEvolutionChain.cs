using Newtonsoft.Json;

namespace PokedexModels.Models
{
    public class PokemonEvolutionChain
    {

        public static string URL_GET_ID = "https://pokeapi.co/api/v2/evolution-chain/";

        [JsonProperty("chain")]
        public EvolutionChain Evolution { get; set; }


        public override string ToString()
        {
            return $"{Evolution}";
        }
    }
}
