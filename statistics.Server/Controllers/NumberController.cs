using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using statistics.Server.Services;
using TrackerApi;
using WikiClientLibrary.Client;
using WikiClientLibrary.Sites;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace statistics.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    public class NumberController : Controller
    {
        public int Sum { get; set; }

        private readonly AppState _state;
        public NumberController(AppState state)
        {
            _state = state;
            Sum = _state.FotimeCeskoPhotos;
            _state.OnFotimeCeskoPhotosUpdated += OnFotimeCeskoPhotosUpdated;

            // Init wiki communication
            wc = new WikiClient
            {
                ClientUserAgent = "Urbanecm's testing webapp (urbanecm@tools.wmflabs.org)"
            };
            cswiki = InitWiki("https://cs.wikipedia.org/w/api.php").Result;
        }

        WikiClient wc;
        WikiSite cswiki;
        private async Task<WikiSite> InitWiki(string url)
        {
            WikiSite s = new WikiSite(wc, url);
            await s.Initialization;
            return s;
        }

        public int FotimeCeskoPhotos()
        {
            _state.UpdateFotimeCeskoPhotos();
            return Sum;
        }

        public void OnFotimeCeskoPhotosUpdated()
        {
            Sum = _state.FotimeCeskoPhotos;
        }
    }
}
