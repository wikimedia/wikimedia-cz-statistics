using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerClient.JsonModels
{
    public class Topic
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
