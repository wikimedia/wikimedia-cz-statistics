using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TrackerApi.JsonModels;
using System.Linq;
using Newtonsoft.Json;

namespace TrackerApi
{
    #region Constructors
    public partial class TrackerClient
    {
        private readonly HttpClient _http;
        public TrackerClient()
        {
            _http = new HttpClient();
            _http.BaseAddress = new Uri("https://tracker.wikimedia.cz/api/");
        }
    }
    #endregion

    #region GET
    public partial class TrackerClient
    {
        public async Task<List<Mediainfo>> GetMediainfos(string topic)
        {
            return await GetMediainfos(new string[] { topic });
        }
        public async Task<List<Mediainfo>> GetMediainfos(string[] topics = null)
        {
            var resp = await _http.GetAsync($"tracker/mediainfo/");
            string respString = await resp.Content.ReadAsStringAsync();

            List<Mediainfo> mediainfos = JsonConvert.DeserializeObject<List<Mediainfo>>(respString);
            if (topics != null)
                mediainfos = mediainfos.Where(mi => topics.Contains(mi.Topic)).ToList();
            return mediainfos;
        }
        public async Task<Mediainfo> GetMediainfo(int id)
        {
            var resp = await _http.GetAsync($"tracker/mediainfo/{id}");
            string respString = await resp.Content.ReadAsStringAsync();
            return JObject.Parse(respString).ToObject<Mediainfo>();
        }
    }
    #endregion

}
