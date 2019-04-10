using Newtonsoft.Json;

namespace WikistatsClient.JsonModels
{
    public class TopByEditsTop
    {
        [JsonProperty("page_title")]
        public string PageTitle { get; set; }
        [JsonProperty("edits")]
        public int Edits { get; set; }
        [JsonProperty("rank")]
        public int Rank { get; set; }
    }
}