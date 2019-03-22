using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaWikiClient.JsonModels
{
    public class Page
    {
        [JsonProperty("pageid")]
        public int PageId { get; set; }
        [JsonProperty("ns")]
        public int Namespace { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("globalusage")]
        public List<GlobalUsage> GlobalUsage { get; set; }

    }
}
