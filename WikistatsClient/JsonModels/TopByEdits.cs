using Newtonsoft.Json;
using System.Collections.Generic;

namespace WikistatsClient.JsonModels
{
    public class TopByEdits
    {
        [JsonProperty("project")]
        public string Project { get; set; }
        [JsonProperty("editor-type")]
        public string EditorType { get; set; }
        [JsonProperty("page-type")]
        public string PageType { get; set; }
        [JsonProperty("granularity")]
        public string Granularity { get; set; }
        [JsonProperty("results")]
        public List<TopByEditsResult> Results { get; set; }
    }
}