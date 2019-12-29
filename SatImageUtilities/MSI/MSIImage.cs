using SatImageUtilities.Tile;

namespace SatImageUtilities.MSI
{
    public class MSIImage
    {
        /// <summary>
        /// Tile position corresponding to this image. 
        /// </summary>
        public S2ATilePosition TilePosition { get; set; }

        /// <summary>
        /// Blue MSI band.
        /// </summary>
        public MSIBand Band2 { get; set; }

        /// <summary>
        /// Green MSI band.
        /// </summary>
        public MSIBand Band3 { get; set; }

        /// <summary>
        /// Red MSI band.
        /// </summary>
        public MSIBand Band4 { get; set; }
    }
}
