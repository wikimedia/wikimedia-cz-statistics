using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackerApi;

namespace statistics.Server.Services
{
    public class AppState
    {
        public int FotimeCeskoPhotos { get; set; } = 0;

        private readonly TrackerClient _tc;
        public AppState(TrackerClient tc)
        {
            _tc = tc;
        }

        public event Action OnFotimeCeskoPhotosUpdated;

        public async void UpdateFotimeCeskoPhotos()
        {
            Dictionary<int, string> yearToTopicMapper = new Dictionary<int, string>
            {
                [2019] = "1.1. Multimédia: Fotíme Česko/Mediagrant",
                [2018] = "1.1. Fotíme Česko (Mediagrant)18"
            };

            List<Task> tasks = new List<Task>();

            foreach (var item in yearToTopicMapper)
            {
                tasks.Add(GetMediaInfo(item.Value));
            }

            Task.WaitAll(tasks.ToArray());

            OnFotimeCeskoPhotosUpdated();
        }

        public async Task<bool> GetMediaInfo(string topic)
        {
            var tmp = await _tc.GetMediainfos(topic);
            FotimeCeskoPhotos += tmp.Count;

            return true;
        }
    }
}
