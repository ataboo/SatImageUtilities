using System;
using Newtonsoft.Json;
using SatImageUtilities.GeoPos;

namespace SatImageUtilities.Tile
{
    [Serializable]
    public class S2ATileFootprint
    {        
        [JsonProperty("tile")]
        public S2ATilePosition TilePosition { get; set; }

        [JsonProperty("points")]
        public LatLong[] Points { get; set; }
    }
}
