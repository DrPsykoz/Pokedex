﻿using Newtonsoft.Json;

namespace Pokedex.Models
{
    public class Type
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

    }
}