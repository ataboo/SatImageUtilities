using SatImageUtilities.Tile;

namespace SatImageUtilities.MSI
{ 
    public class MSIBand
    {
        public string FilePath { get; set; }

        public int Band { get; set; }

        public int ResolutionM { get; set; }

        public double[][] Data { get; set; }

        public S2ATilePosition TilePosition { get; set; }
    }
}
