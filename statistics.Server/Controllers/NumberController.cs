using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackerApi;
using WikiClientLibrary.Client;
using WikiClientLibrary.Sites;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace statistics.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    public class NumberController : Controller
    {
        int sum = 0;
        int isFinished = 0;
        TrackerClient tc;
        WikiClient wc;
        WikiSite cswiki;
        private async Task<WikiSite> InitWiki(string url)
        {
            WikiSite s = new WikiSite(wc, url);
            await s.Initialization;
            return s;
        }
        public NumberController()
        {
            // Init Tracker communication
            tc = new TrackerClient();

            // Init wiki communication
            wc = new WikiClient
            {
                ClientUserAgent = "Urbanecm's testing webapp (urbanecm@tools.wmflabs.org)"
            };
            cswiki = InitWiki("https://cs.wikipedia.org/w/api.php").Result;
        }

        public int FotimeCeskoPhotos()
        {
            Dictionary<int, string> yearToTopicMapper = new Dictionary<int, string>
            {
                [2019] = "1.1. Multimédia: Fotíme Česko/Mediagrant",
                [2018] = "1.1. Fotíme Česko (Mediagrant)18"
            };
            foreach (var item in yearToTopicMapper)
            {
                GetMediaInfo(item.Value);
            }
            while (isFinished != yearToTopicMapper.Count)
            {
            }
            return sum;
        }

        public async void GetMediaInfo(string topic)
        {
            var tmp = await tc.GetMediainfos(topic);
            sum += tmp.Count;
            isFinished += 1;
        }
    }
}
