using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MediaWikiClient.JsonModels
{
    public class GenericResponse
    {
        private Dictionary<string, Page> pages;

        [JsonProperty("batchcomplete")]
        public string Batchcomplete { get; set; }
        [JsonProperty("continue")]
        public Dictionary<string, string> Continue { get; set; }
        [JsonProperty("query")]
        public Dictionary<string, object> Query { get; set; }
        public Dictionary<string, Page> Pages {
            get
            {
                while(pages == null)
                {
                    Thread.Sleep(10);
                }
                return pages;
            }
            set
            {
                pages = value;
            }
        }
        [JsonProperty("Limits")]
        public Dictionary<string, int> Limits { get; set; }

        public GenericResponse()
        {
            new Thread(() =>
            {
                while (Query == null)
                {
                    Thread.Sleep(10);
                }
                Pages = ((JObject)Query["pages"]).ToObject<Dictionary<string, Page>>();
            }).Start();
        }
    }
}
