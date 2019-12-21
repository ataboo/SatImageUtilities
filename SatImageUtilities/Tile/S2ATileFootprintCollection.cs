using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SatImageUtilities.Tile
{
    [Serializable]
    public class S2ATileFootprintCollection
    {
        [JsonProperty("footprints")]
        public Dictionary<S2ATilePosition, S2ATileFootprint> Footprints { get; set; }

        [JsonProperty("date")]
        public DateTime CompileDate { get; set; }

        [JsonProperty("kml_file")]
        public string KMLFile { get; set; }
    }
}
