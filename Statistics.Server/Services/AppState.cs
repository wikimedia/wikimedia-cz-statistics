using MediaWikiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackerClient;

namespace statistics.Server.Services
{
    public class AppState
    {
        public int FotimeCeskoNumberOfPhotos { get; set; } = 0;
        public int FotimeCeskoNumberOfUsages { get; set; } = 0;

        private readonly Tracker _tc;
        private readonly MediaWiki _commonswiki;
        public AppState(Tracker tc, MediaWiki commonswiki)
        {
            _tc = tc;
            _commonswiki = commonswiki;
        }

        public async void UpdateFotimeCeskoNumberOfPhotos()
        {
            FotimeCeskoNumberOfPhotos = (await _tc.GetMediainfos()).Count;
        }

        public async void UpdateFotimeCeskoNumberOfUsages()
        {
            int res = 0;
            var mediainfos = await _tc.GetMediainfos();
            foreach (var mediainfo in mediainfos)
            {
                res += (await _commonswiki.GetGlobalUsagesOfFile(mediainfo.Name)).Count; // TODO: Get rid of await in foreach
            }
            FotimeCeskoNumberOfUsages = res;
        }
    }
}
