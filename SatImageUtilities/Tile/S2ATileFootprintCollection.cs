using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SatImageUtilities.Tile
{
    public class S2ATileFootprintCollection
    {
        [JsonProperty("footprints")]
        /// <summary>
        /// Sentinel 2 tiles mapped to their footprints.
        /// </summary>
        public Dictionary<S2ATilePosition, S2ATileFootprint> Footprints { get; set; }

        [JsonProperty("date")]
        /// <summary>
        /// The date this collection was loaded from the original KML
        /// </summary>
        public DateTime CompileDate { get; set; }

        [JsonProperty("kml_file")]
        /// <summary>
        /// The original KML file this collection was loaded from.
        /// </summary>
        public string KMLFile { get; set; }
    }
}
