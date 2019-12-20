using System;
using System.Collections.Generic;
using System.Text;

namespace SatImageUtilities.Tile
{
    public class S2ATileFootprintCollection
    {
        public Dictionary<S2ATilePosition, S2ATileFootprint> Footprints { get; set; }

        public DateTime CompileDate { get; set; }

        public string KMLFile { get; set; }
    }
}
