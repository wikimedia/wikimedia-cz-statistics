using Newtonsoft.Json;
using System.Collections.Generic;

namespace WikistatsClient.JsonModels
{
    public class Response<T>
    {
        [JsonProperty("items")]
        public List<T> Items { get; set; }
    }
}
