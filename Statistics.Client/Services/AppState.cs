using Statistics.Client;
using Statistics.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics.Client.Services
{
    public class AppState
    {
        public Number Number{ get; set; }

        private readonly AppClient _client;
        public AppState(AppClient client)
        {
            _client = client;
        }
    }
}
