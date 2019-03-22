using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace statistics.Shared
{
    public class Tile
    {
        public string name { get; set; }
        public string type { get; set; }
        public string url { get; set; }

        public string Payload { get; set; }
    }
}
