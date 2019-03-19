using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using statistics.Client.Services;

namespace statistics.Client.Pages
{
    public class GridPage : ComponentBase
    {
        [Inject] public AppState State { get; set; }
        public int NumberOfPhotos { get; set; }
        protected override void OnInit()
        {
            NumberOfPhotos = State.NumberOfPhotos;
            State.OnNumberPhotosUpdated += OnNumberOfPhotosUpdated;
            State.UpdateNumberOfPhotos();
        }

        public void OnNumberOfPhotosUpdated()
        {
            NumberOfPhotos = State.NumberOfPhotos;
        }
    }
}
