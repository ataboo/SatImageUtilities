using System;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using SatImageUtilities.GeoPos;

namespace SatImageUtilities.Tile
{
    [Serializable]
    public class S2ATileFootprint
    {        
        [JsonProperty("tile")]
        public S2ATilePosition TilePosition { get; set; }

        private ReadOnlyCollection<LatLong> _points { get; set; }
        [JsonProperty("points")]
        public ReadOnlyCollection<LatLong> Points {
            get => _points;
            set {
                _bounds.ne = null;
                _bounds.sw = null;
                _points = value;
            }
        }

        public bool SpansIDL => Math.Abs(Bounds.ne.LongRads - Bounds.sw.LongRads) > Math.PI;

        private (LatLong ne, LatLong sw) _bounds;
        public (LatLong ne, LatLong sw) Bounds {
            get {
                if (_bounds.ne == null) {
                    var(west, east) = GetLongitudeBounds();

                    var north = Points.Max(p => p.LatRads);
                    var south = Points.Min(p => p.LatRads);

                    _bounds = (new LatLong{ LatRads = north, LongRads = east }, new LatLong{ LatRads = south, LongRads = west });
                }
                return _bounds;
            }
        }

        private (double westRads, double eastRads) GetLongitudeBounds() {
            var normLongitudes = Points.Select(p => (p.LongRads + Math.PI * 2) % (Math.PI * 2));
            
            var min = double.MaxValue;
            var max = double.MinValue;
            foreach(var longRad in normLongitudes) {
                min = Math.Min(longRad, min);
                max = Math.Max(longRad, max);
            }

            min = min > Math.PI ? min-Math.PI * 2 : min;
            max = max > Math.PI ? max-Math.PI * 2 : max;
            
            return min > max ? (max, min) : (min, max);
        }

        public bool ContainsPoint(LatLong point) {
            if(point.LatRads > Bounds.ne.LatRads || point.LatRads < Bounds.sw.LatRads) {
                return false;
            }
            
            if (SpansIDL) {
                return point.LongRads > Bounds.ne.LongRads || point.LongRads < Bounds.sw.LongRads;
            }

            return point.LongRads <= Bounds.ne.LongRads && point.LongRads >= Bounds.sw.LongRads;
        }
    }
}
