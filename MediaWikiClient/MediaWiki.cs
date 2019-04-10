using MediaWikiClient.JsonModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Web;

namespace MediaWikiClient
{
    #region Constructors and helpers
    public partial class MediaWiki
    {
        private readonly HttpClient _http;
        public string Project { get; private set; }
        public MediaWiki(string project, string apiUrl="/w/api.php", string proto="https")
        {
            Project = project;

            _http = new HttpClient();
            _http.BaseAddress = new Uri($"{proto}://{project}/{apiUrl}");
        }

        private string ToQueryString(NameValueCollection nvc)
        {
            var array = (from key in nvc.AllKeys
                         from value in nvc.GetValues(key)
                         select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)))
                .ToArray();
            return "?" + string.Join("&", array);
        }

        public async Task<GenericResponse> ApiCallAsync(NameValueCollection parameters, bool resolveContinue=true)
        {
            var querystring = ToQueryString(parameters);
            var resp = await _http.GetAsync(querystring);
            string respString = await resp.Content.ReadAsStringAsync();
            var data = JObject.Parse(respString).ToObject<GenericResponse>();

            if (resolveContinue && data.Continue != null)
                await ResolveContinueAsync(data, parameters);

            return data;
        }

        private async Task ResolveContinueAsync(GenericResponse data, NameValueCollection parameters)
        {
            if (data.Continue != null)
            {
                foreach (KeyValuePair<string, string> contParam in data.Continue)
                {
                    parameters[contParam.Key] = contParam.Value;
                }
                var newData = await ApiCallAsync(parameters, false);
                data.Update(newData);
                if (data.Continue != null)
                    await ResolveContinueAsync(data, parameters);
            }
        }
    }
    #endregion
    #region GETs
    public partial class MediaWiki
    {
        public static NameValueCollection DefaultParameters
        {
            get => new NameValueCollection
            {
                {"format", "json" }
            };
        }
        public async Task<List<GlobalUsage>> GetGlobalUsagesOfFile(string filename)
        {
            var page = await GetPage(filename, new NameValueCollection
            {
                {"prop", "globalusage" },
                {"gulimit", "max" }

            });
            return page.GlobalUsage;
        }

        public async Task<Page> GetPage(string pagename, NameValueCollection extraParams=null)
        {
            NameValueCollection parameters = DefaultParameters;
            parameters["action"] = "query";
            parameters["titles"] = pagename;
            foreach (string key in extraParams)
            {
                parameters[key] = extraParams[key];
            }
            var resp = await ApiCallAsync(parameters);
            var page = resp.Pages[resp.Pages.Keys.ToArray()[0]];
            page.Project = Project;
            return page;
        }
    }
    #endregion
}
