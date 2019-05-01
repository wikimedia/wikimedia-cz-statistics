using statistics.Shared.Report.Interfaces;
using System.Collections.Generic;
using TrackerClient;
using TrackerClient.JsonModels;

namespace statistics.Shared.Report.Models
{
    public class Mediainfos : ICountable
    {
        private List<Mediainfo> mediainfos;
        public Mediainfo[] Media => mediainfos.ToArray(); 
        public int Count => mediainfos.Count;
        public Mediainfos()
        {
            mediainfos = new List<Mediainfo>();
        }
        public Mediainfos(params Topic[] topics)
        {
            Tracker tc = new Tracker();
            mediainfos = tc.GetMediainfos(topics).Result;
        }
    }
}
