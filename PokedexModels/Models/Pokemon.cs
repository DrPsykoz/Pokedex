using Newtonsoft.Json;
using System.Collections.Generic;

namespace Pokedex.Models
{
    public class Pokemon
    {
        [JsonProperty("id")]
        public int ID { get; }
        [JsonProperty("name")]
        public string Name { get; }
        [JsonProperty("weight")]
        public int Weight { get; }
        [JsonProperty("height")]
        public int Height { get; }
        [JsonProperty("types")]
        public List<SlotType> SlotTypes { get; set; }

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
