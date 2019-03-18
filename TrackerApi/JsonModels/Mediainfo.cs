using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerApi.JsonModels
{
    public class Mediainfo
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("descriptionurl")]
        public string DescriptionUrl { get; set; }
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("height")]
        public string Height { get; set; }
        [JsonProperty("thumb_url")]
        public string ThumbUrl { get; set; }
        [JsonProperty("canonicaltitle")]
        public string CanonicalTitle { get; set; }
        [JsonProperty("ticket")]
        public string Ticket { get; set; }
        /*[JsonProperty("categories")]
        public List<string> Categories { get; set; }*/
    }
}
