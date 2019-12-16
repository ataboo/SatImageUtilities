using SatImageUtilities.GeoPos;

namespace SatImageUtilities.Tile
{
    public class S2ATileFootprint
    {        
        public S2ATilePosition TilePosition { get; set; }

        public LatLong[] Points { get; set; }
    }
}
