using System.Threading.Tasks;

namespace SatImageUtilities.Tile
{ 
    public interface IKMLFileService
    {
        Task<S2ATileFootprintCollection> LoadFromKMLFile(string kmlFilePath);
    }
}
