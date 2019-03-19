using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace statistics.Client.Components
{
    public class ChartComponent : ComponentBase
    {
        [Inject]
        public IJSRuntime jsRuntime { get; set; }

        protected override void OnInit()
        {
            jsRuntime.InvokeAsync<bool>("createChart");
        }
    }
}
