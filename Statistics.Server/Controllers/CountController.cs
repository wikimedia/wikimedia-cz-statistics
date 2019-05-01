using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using statistics.Shared;
using statistics.Shared.Report.Models;
using TrackerClient.JsonModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Statistics.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CountController : Controller
    {
        public Number Mediainfos(int[] topics)
        {
            Mediainfos mis = new Mediainfos(topics);
            return new Number()
            {
                value = mis.Count
            };
        }
    }
}
