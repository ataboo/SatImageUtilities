using System.Threading.Tasks;

namespace SatImageUtilities.Tile
{ 
    public interface IKMLFileService
    {
        /// <summary>
        /// Load and parse a Sentinel 2 Tiling Grid KML file to get the footprint positions.
        /// </summary>
        Task<S2ATileFootprintCollection> LoadFromKMLFile(string kmlFilePath);
    }
}
