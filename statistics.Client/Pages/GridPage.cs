using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using statistics.Client.Services;
using statistics.Shared;

namespace statistics.Client.Pages
{
    public class GridPage : ComponentBase
    {
        [Inject] public AppState State { get; set; }
        [Inject] public HttpClient Client { get; set; }
        public IEnumerable<Tile> Tiles { get; set; }
        public int NumberOfPhotos { get; set; }
        protected override void OnInit()
        {
            Tiles = new List<Tile>();
            LoadTiles();
            //NumberOfPhotos = State.NumberOfPhotos;
            //State.OnNumberPhotosUpdated += OnNumberOfPhotosUpdated;
            //State.UpdateNumberOfPhotos();
        }

        public void OnNumberOfPhotosUpdated()
        {
            NumberOfPhotos = State.NumberOfPhotos;
        }

        public async void LoadTiles()
        {
            Tiles = await Client.GetJsonAsync<List<Tile>>("tiles.json");
            foreach (var tile in Tiles)
            {
                switch (tile.type.ToLower())
                {
                    case "number":
                        tile.Payload = Json.Serialize(await Client.GetJsonAsync<Number>(tile.url));
                        break;
                }
            }
            StateHasChanged();
        }
    }
}
