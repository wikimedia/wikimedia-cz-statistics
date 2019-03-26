using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

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

        public void Update(GenericResponse response)
        {
            Continue = response.Continue;
            foreach (KeyValuePair<string, Page> item in Pages)
            {
                Page ourPage = item.Value;
                Page theirPage = response.Pages[item.Key];
                PropertyInfo[] properties = typeof(Page).GetProperties();
                foreach (var property in properties)
                {
                    Type type = property.PropertyType;
                    bool isList = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
                    if (isList)
                    {
                        var theirValue = property.GetValue(theirPage) as IList;
                        var ourValue = property.GetValue(ourPage) as IList;
                        foreach (var i in theirValue)
                        {
                            ourValue.Add(i);
                        }
                    }
                }
            }
        }
    }
}
