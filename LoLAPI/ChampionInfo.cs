using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LoLAPI
{
    public class ChampionInfo
    {
        [JsonPropertyName("attack")]
        public int Attack { get; set; }

        [JsonPropertyName("defense")]
        public int Defense { get; set; }
    }
}
