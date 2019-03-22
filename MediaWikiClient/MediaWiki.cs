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

        public async Task<GenericResponse> ApiCallAsync(NameValueCollection parameters, bool resolveContinue=false)
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
                var newData = await ApiCallAsync(parameters);
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
        public async Task<List<GlobalUsage>> GetGlobalUsagesOfFile(string filename)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters["action"] = "query";
            parameters["format"] = "json";
            parameters["prop"] = "globalusage";
            parameters["titles"] = filename;
            parameters["gulimit"] = "max";
            var resp = await ApiCallAsync(parameters, true);
            return resp.Pages[resp.Pages.Keys.ToArray()[0]].GlobalUsage;
        }
    }
    #endregion
}
