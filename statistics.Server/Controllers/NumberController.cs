using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using statistics.Server.Services;
using statistics.Shared;
using TrackerApi;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace statistics.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    public class NumberController : Controller
    {
        private int _fotimeCeskoNumberOfPhotos;
        private int _fotimeCeskoNumberOfUsages;
        private readonly AppState _state;
        public NumberController(AppState state)
        {
            _state = state;
            _state.OnFotimeCeskoNumberOfPhotosUpdated += OnFotimeCeskoNumberOfPhotosUpdated;
            _fotimeCeskoNumberOfPhotos = _state.FotimeCeskoNumberOfPhotos;
            _state.OnFotimeCeskoNumberOfPhotosUpdated += OnFotimeCeskoNumberOfUsagesUpdated;
            _fotimeCeskoNumberOfPhotos = _state.FotimeCeskoNumberOfUsages;
        }

        public Number FotimeCeskoNumberOfPhotos()
        {
            return new Number
            {
                value = _fotimeCeskoNumberOfPhotos
            };
        }

        public Number FotimeCeskoNumberOfUsages()
        {
            return new Number
            {
                value = _fotimeCeskoNumberOfUsages
            };
        }

        public void OnFotimeCeskoNumberOfPhotosUpdated()
        {
            _fotimeCeskoNumberOfPhotos = _state.FotimeCeskoNumberOfPhotos;
        }

        public void OnFotimeCeskoNumberOfUsagesUpdated()
        {
            _fotimeCeskoNumberOfUsages = _state.FotimeCeskoNumberOfUsages;
        }
    }
}
