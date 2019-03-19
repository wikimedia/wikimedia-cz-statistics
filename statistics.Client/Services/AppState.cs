using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace statistics.Client.Services
{
    public class AppState
    {
        private readonly AppClient _client;
        public AppState(AppClient client)
        {
            _client = client;
        }
    }
}
