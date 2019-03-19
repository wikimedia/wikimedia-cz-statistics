using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace statistics.Client.Services
{
    public class AppClient
    {
        private readonly HttpClient _http;
        public AppClient(HttpClient http)
        {
            _http = http;
        }
    }
}
