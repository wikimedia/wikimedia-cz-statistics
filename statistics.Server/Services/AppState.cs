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

        private readonly TrackerClient _tc;
        public AppState(TrackerClient tc)
        {
            _tc = tc;
        }

        public event Action OnFotimeCeskoNumberOfPhotosUpdated;

        public async void UpdateFotimeCeskoNumberOfPhotos()
        {
            FotimeCeskoPhotos = (await _tc.GetMediainfos()).Count;
            OnFotimeCeskoNumberOfPhotosUpdated();
        }
    }
}
