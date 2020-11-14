using Newtonsoft.Json;

namespace PokedexModels.Models
{
    public class Language
    {
        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
