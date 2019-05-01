using Statistics.Shared.Report.Interfaces;
using System;
using System.Collections.Generic;
using TrackerClient;
using TrackerClient.JsonModels;

namespace Statistics.Shared.Report.Models
{
    public class Mediainfos : ICountable
    {
        private List<Mediainfo> mediainfos = new List<Mediainfo>();
        public Mediainfo[] Media => mediainfos.ToArray(); 
        public int Count => mediainfos.Count;
        public Mediainfos(int[] topicsIds)
        {
            Tracker tc = new Tracker();
            Topic[] topics = tc.GetTopics(topicsIds).Result;
            mediainfos = tc.GetMediainfos(topics).Result;
        }
    }
}
