using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TrackerApi.JsonModels;

namespace TrackerApi
{
    //Constructors
    public partial class TrackerClient
    {
        private readonly HttpClient _http;
        public TrackerClient()
        {
            _http = new HttpClient();
            _http.BaseAddress = new Uri("https://tracker.wikimedia.cz/api/");
        }
    }
    //GET
    public partial class TrackerClient
    {
        public async Task<Mediainfo> GetMediainfo(int id)
        {
            var resp = await _http.GetAsync($"tracker/mediainfo/{id}");
            string respString = await resp.Content.ReadAsStringAsync();
            return JObject.Parse(respString).ToObject<Mediainfo>();
        }
    }

}
