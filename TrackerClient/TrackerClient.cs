using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TrackerApi.JsonModels;
using System.Linq;

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
        public async Task<List<Mediainfo>> GetMediainfos(string topic=null)
        {
            var resp = await _http.GetAsync($"tracker/mediainfo/");
            string respString = await resp.Content.ReadAsStringAsync();
            List<Mediainfo> mediainfos = JObject.Parse(respString).ToObject<List<Mediainfo>>();
            if (topic != null)
                mediainfos = mediainfos.Where(mi => mi.Topic == topic).ToList();
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
