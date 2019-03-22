using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;

namespace MediaWikiClient.JsonModels
{
    public class GenericResponse
    {
        [JsonProperty("batchcomplete")]
        public string Batchcomplete { get; set; }
        [JsonProperty("continue")]
        public Dictionary<string, string> Continue { get; set; }
        [JsonProperty("query")]
        public Dictionary<string, object> Query { get; set; }
        public Dictionary<string, Page> Pages { get; set; }
        [JsonProperty("Limits")]
        public Dictionary<string, int> Limits { get; set; }

        [OnDeserialized]
        public void DeserializeQuery(StreamingContext context)
        {
            Pages = ((JObject)Query["pages"]).ToObject<Dictionary<string, Page>>();
        }
    }
}
