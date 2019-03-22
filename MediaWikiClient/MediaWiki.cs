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
        public MediaWiki(string project, string apiUrl="/w/api.php", string proto="https")
        {
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

        public async Task<GenericResponse> ApiCallAsync(NameValueCollection parameters)
        {
            var querystring = ToQueryString(parameters);
            var resp = await _http.GetAsync(querystring);
            string respString = await resp.Content.ReadAsStringAsync();
            return JObject.Parse(respString).ToObject<GenericResponse>();
        }
    }
    #endregion
    #region GETs
    public partial class MediaWiki
    {
        public async Task<List<GlobalUsage>> GetGlobalUsagesOfFile(string filename)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters["action"] = "query";
            parameters["format"] = "json";
            parameters["prop"] = "globalusage";
            parameters["list"] = "allusers";
            parameters["titles"] = filename;
            parameters["gulimit"] = "max";
            var resp = await ApiCallAsync(parameters);
            return resp.Pages[resp.Pages.Keys.ToArray()[0]].GlobalUsage;
        }
    }
    #endregion
}
