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
        private readonly WikiClient _wc;
        WikiSite cswiki;
        public NumberController(AppState state, WikiClient wc)
        {
            _state = state;
            _wc = wc;
            Sum = _state.FotimeCeskoPhotos;
            _state.OnFotimeCeskoPhotosUpdated += OnFotimeCeskoPhotosUpdated;

            cswiki = InitWiki("https://cs.wikipedia.org/w/api.php").Result;
        }
        private async Task<WikiSite> InitWiki(string url)
        {
            WikiSite s = new WikiSite(_wc, url);
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
