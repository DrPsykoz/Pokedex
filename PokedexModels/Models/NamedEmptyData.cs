using Newtonsoft.Json;

namespace PokedexModels.Models
{
    public class NamedEmptyData
    {

        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
