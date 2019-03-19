using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackerApi;
using TrackerApi.JsonModels;
using WikiClientLibrary.Client;
using WikiClientLibrary.Generators;
using WikiClientLibrary.Pages;
using WikiClientLibrary.Sites;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace statistics.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TestController : Controller
    {
        TrackerClient tc;
        WikiClient wc;
        WikiSite cswiki;
        private async Task<WikiSite> InitWiki(string url)
        {
            WikiSite s = new WikiSite(wc, url);
            await s.Initialization;
            return s;
        }
        public TestController()
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
        public async Task<Mediainfo> TohleJeSubNeco()
        {
            return await tc.GetMediainfo(9236);
        }

        public async Task<IEnumerable<WikiPage>> MediawikiStrangeResult()
        {
            var generator = new AllPagesGenerator(cswiki)
            {
                StartTitle = "Mar"
            };
            var pages = await generator.EnumPagesAsync().Take(10).ToList();
            foreach (var page in pages)
            {
                page.Content = "";
            }
            return pages;
        }

        public async Task<IEnumerable<string>> Mediawiki()
        {
            var generator = new AllPagesGenerator(cswiki)
            {
                StartTitle = "Mar"
            };
            var pages = await generator.EnumPagesAsync().Take(10).ToList();
            foreach (var page in pages)
            {
                page.Content = "";
            }
            return pages.Select(p => p.Title);
        }
    }
}
