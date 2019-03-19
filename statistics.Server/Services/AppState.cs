using statistics.Server.Helpers;
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
        public int FotimeCeskoPhotosTmp { get; set; } = 0;

        private readonly TrackerClient _tc;
        public AppState(TrackerClient tc)
        {
            _tc = tc;
        }

        public event Action OnFotimeCeskoPhotosUpdated;

        public void UpdateFotimeCeskoPhotos()
        {
            FotimeCeskoPhotosTmp = 0;

            Dictionary<int, string> yearToTopicMapper = new Dictionary<int, string>
            {
                [2019] = "1.1. Multimédia: Fotíme Česko/Mediagrant",
                [2018] = "1.1. Fotíme Česko (Mediagrant)18"
            };

            List<Task> tasks = new List<Task>();

            foreach (var item in yearToTopicMapper)
            {
                tasks.Add(TrackerClientHelper.GetMediaInfo(_tc, this, item.Value));
            }

            Task.WaitAll(tasks.ToArray());

            FotimeCeskoPhotos = FotimeCeskoPhotosTmp;

            OnFotimeCeskoPhotosUpdated();
        }
    }
}
