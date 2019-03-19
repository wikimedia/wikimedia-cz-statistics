using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace statistics.Client.Services
{
    public class AppClient
    {
        private readonly HttpClient _http;
        public AppClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<int> GetNumberOfPhotos()
        {
            return await _http.GetJsonAsync<int>("/api/Number/FotimeCeskoPhotos");
        }
    }
}
