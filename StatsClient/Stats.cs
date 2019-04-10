using Newtonsoft.Json.Linq;
using StatsClient.JsonModels;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StatsClient
{
    #region Constructors and helpers
    public partial class Stats
    {
        private readonly HttpClient _http;
        public string Project { get; private set; }
        public Stats(string project)
        {
            Project = project;

            _http = new HttpClient();
            _http.BaseAddress = new Uri("https://wikimedia.org/api/rest_v1/");
        }
        public async Task<T> ApiCallAsync<T>(string url)
        {
            var resp = await _http.GetAsync(url);
            string respString = await resp.Content.ReadAsStringAsync();
            return JObject.Parse(respString).ToObject<T>();
        }

    }
    #endregion

    #region GETs
    public partial class Stats
    {
        public async Task<Response<TopByEdits>> TopByEdits(string editorType, string pageType, int year, int month, int? day=null)
        {
            string monthCorrect = month.ToString();
            if (monthCorrect.Length == 1)
            {
                monthCorrect = "0" + monthCorrect;
            }
            string dayCorrect = day != null ? day.ToString() : "all-days";
            return await ApiCallAsync<Response<TopByEdits>>($"metrics/edited-pages/top-by-edits/{Project}/{editorType}/{pageType}/{year}/{monthCorrect}/{dayCorrect}");
        }
    }
    #endregion
}
