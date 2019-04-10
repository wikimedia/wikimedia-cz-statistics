using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TrackerClient.JsonModels;
using System.Linq;
using Newtonsoft.Json;

namespace TrackerClient
{
    #region Constructors
    public partial class Tracker
    {
        private readonly HttpClient _http;
        public Tracker()
        {
            _http = new HttpClient();
            _http.BaseAddress = new Uri("https://tracker.wikimedia.cz/api/");
        }
    }
    #endregion

    #region GET
    public partial class Tracker
    {
        public async Task<List<Mediainfo>> GetMediainfos(Topic topic)
        {
            return await GetMediainfos(new Topic[] { topic });
        }
        public async Task<List<Mediainfo>> GetMediainfos(Topic[] topics = null)
        {
            var resp = await _http.GetAsync($"tracker/mediainfo/");
            string respString = await resp.Content.ReadAsStringAsync();

            List<Mediainfo> mediainfos = JsonConvert.DeserializeObject<List<Mediainfo>>(respString);
            if (topics != null)
                mediainfos = mediainfos.Where(mi => topics.Select(t => t.Name).Contains(mi.Topic)).ToList();
            return mediainfos;
        }
        public async Task<Mediainfo> GetMediainfo(int id)
        {
            var resp = await _http.GetAsync($"tracker/mediainfo/{id}");
            string respString = await resp.Content.ReadAsStringAsync();
            return JObject.Parse(respString).ToObject<Mediainfo>();
        }

        public async Task<Topic> GetTopic(int id)
        {
            var resp = await _http.GetAsync($"tracker/topics/{id}");
            string respString = await resp.Content.ReadAsStringAsync();
            return JObject.Parse(respString).ToObject<Topic>();
        }
    }
    #endregion

}
