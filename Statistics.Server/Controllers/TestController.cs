using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackerClient;
using TrackerClient.JsonModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace statistics.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TestController : Controller
    {
        Tracker tc;
        public TestController()
        {
            // Init Tracker communication
            tc = new Tracker();
        }
        public async Task<Mediainfo> TohleJeSubNeco()
        {
            return await tc.GetMediainfo(9236);
        }

        public int Cislo()
        {
            return 10;
        }
    }
}
