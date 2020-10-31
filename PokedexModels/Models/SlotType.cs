using Newtonsoft.Json;

namespace Pokedex.Models
{
    public class SlotType
    {
        [JsonProperty("slot")]
        public int Slot { get; set; }
        [JsonProperty("type")]
        public Type Type { get; set; }

        public override string ToString()
        {
            return $"{Slot} {Type}";
        }

    }
}