using SatImageUtilities.Tile;

namespace SatImageUtilities.MSI
{ 
    /// <summary>
    /// Represents data from a single band from the Sentinel 2 MSI.
    /// </summary>
    public class MSIBand
    {
        /// <summary>
        /// Path to the JPG-2000 file.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Band Number.
        /// </summary>
        public int Band { get; set; }

        /// <summary>
        /// Resolution in Meters.
        /// </summary>
        public int ResolutionM { get; set; }

        /// <summary>
        /// Data for the band.
        /// </summary>
        public double[][] Data { get; set; }

        /// <summary>
        /// Tile Position corresponding to this band.
        /// </summary>
        public S2ATilePosition TilePosition { get; set; }
    }
}
