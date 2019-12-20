using SatImageUtilities.Tile;

namespace SatImageUtilities.MSI
{
    public class MSIImage
    {
        public S2ATilePosition TilePosition { get; set; }

        // Blue
        public MSIBand Band2 { get; set; }

        // Green
        public MSIBand Band3 { get; set; }

        // Red
        public MSIBand Band4 { get; set; }
    }
}
