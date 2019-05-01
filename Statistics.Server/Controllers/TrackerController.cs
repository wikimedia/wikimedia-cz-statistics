using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackerClient;
using TrackerClient.JsonModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Statistics.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TrackerController : Controller
    {
        private readonly Tracker _tc;
        public TrackerController(Tracker tc)
        {
            _tc = tc;
        }
        public async Task<Topic[]> GetTopics()
        {
            return await _tc.GetTopics();
        }
    }
}
