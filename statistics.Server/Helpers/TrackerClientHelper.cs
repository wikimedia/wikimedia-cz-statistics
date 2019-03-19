using statistics.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackerApi;

namespace statistics.Server.Helpers
{
    public static class TrackerClientHelper
    {
        public static async Task<bool> GetMediaInfo(TrackerClient _tc, AppState _state, string topic)
        {
            var tmp = await _tc.GetMediainfos(topic);
            _state.FotimeCeskoPhotosTmp += tmp.Count;
            return true;
        }
    }
}
