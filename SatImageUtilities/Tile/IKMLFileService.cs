using System.Threading.Tasks;

namespace SatImageUtilities.Tile
{ 
    public interface IKMLFileService
    {
        Task<S2ATileFootprintCollection> LoadFromKMLFile(string kmlFilePath);

        S2ATileFootprintCollection LoadFromProto(string binFilePath);

        void SaveToProto(string binFilePath, S2ATileFootprintCollection footPrints);
    }
}
