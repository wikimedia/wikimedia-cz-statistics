using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaWikiClient.JsonModels
{
    public class Page
    {
        private string _project = null;
        public string Project
        {
            get => _project;
            set
            {
                if (_project == null)
                {
                    _project = value;
                }
            }
        }
        [JsonProperty("pageid")]
        public int PageId { get; set; }
        [JsonProperty("ns")]
        public int Namespace { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("globalusage")]
        public List<GlobalUsage> globalUsage;
        public List<GlobalUsage> GlobalUsage {
            get
            {
                if (globalUsage == null)
                {
                    // TODO: Make this work for non-standard ApiUrls
                    var tmp = new MediaWiki(Project).GetGlobalUsagesOfFile(Title);
                    globalUsage = tmp.Result;
                    
                }
                return globalUsage;
            }
            set => globalUsage = value;
        }

    }
}
