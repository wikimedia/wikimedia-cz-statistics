using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using statistics.Server.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace statistics.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UpdateController : Controller
    {
        private readonly AppState _state;
        public UpdateController(AppState state)
        {
            _state = state;
        }

        [HttpGet]
        public bool UpdateAll()
        {
            _state.UpdateFotimeCeskoNumberOfPhotos();
            return true;
        }
    }
}
