using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace statistics.Client.Services
{
    public class AppState
    {
        public int NumberOfPhotos { get; set; } = 0;

        private readonly AppClient _client;
        public AppState(AppClient client)
        {
            _client = client;
        }

        public event Action OnNumberPhotosUpdated;

        public async void UpdateNumberOfPhotos()
        {
            NumberOfPhotos = await _client.GetNumberOfPhotos();
            OnNumberPhotosUpdated();
        }
    }
}
