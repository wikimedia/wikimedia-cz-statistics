using Newtonsoft.Json;
using System.Collections.Generic;

namespace StatsClient.JsonModels
{
    public class TopByEditsResult
    {
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
        [JsonProperty("top")]
        public List<TopByEditsTop> Top { get; set; }
    }
}