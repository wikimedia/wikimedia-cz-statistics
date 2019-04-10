using statistics.Shared.Report.Interfaces;
using System.Collections.Generic;
using TrackerApi;
using TrackerApi.JsonModels;

namespace statistics.Shared.Report.Models
{
    public class Mediainfos : ICountable
    {
        private List<Mediainfo> mediainfos;
        public Mediainfo[] Media { get => mediainfos.ToArray(); }
        public int Count() => mediainfos.Count;
        public Mediainfos()
        {
            mediainfos = new List<Mediainfo>();
        }
        public Mediainfos(params Topic[] topics)
        {
            TrackerClient tc = new TrackerClient();
            mediainfos = tc.GetMediainfos(topics).Result;
        }
    }
}
