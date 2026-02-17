using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LoLAPI
{
    public class ChampionDatas
    {
        [JsonPropertyName("data")]
        public Dictionary<string, Champion> Data { get; set; }
    }
}
