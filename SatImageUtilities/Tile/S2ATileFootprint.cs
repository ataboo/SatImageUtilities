using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using SatImageUtilities.GeoPos;

namespace SatImageUtilities.Tile
{
    public class S2ATileFootprint
    {        
        [JsonProperty("tile")]
        /// <summary>
        /// The Sentinel 2 tile grid for this footprint.
        /// </summary>
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

        private LatLong _center { get; set; }
        [JsonProperty("center")]
        /// <summary>
        /// The point at the center of the footprint.
        /// </summary>
        public LatLong Center { 
            get => _center; 
            set {
                _bounds.ne = null; 
                _bounds.sw = null;
            _center = value;
            }
        }

        /// <summary>
        /// Does the footprint span the Internationial Date Line. 
        /// </summary>
        public bool SpansIDL => Math.Abs(Bounds.ne.LongRads - Bounds.sw.LongRads) > Math.PI;

        /// <summary>
        /// Determine if a point falls within this footprint.
        /// </summary>
        public bool ContainsPoint(LatLong point) {
            if(point.LatRads > Bounds.ne.LatRads || point.LatRads < Bounds.sw.LatRads) {
                return false;
            }
            
            if (SpansIDL) {
                return point.LongRads >= Bounds.sw.LongRads || point.LongRads <= Bounds.ne.LongRads;
            }

            return point.LongRads <= Bounds.ne.LongRads && point.LongRads >= Bounds.sw.LongRads;
        }

        private (LatLong ne, LatLong sw) _bounds;
        /// <summary>
        /// The North-East and South-West corners of the footprint.
        /// </summary>
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

        /// <summary>
        /// Set the points that form the bounds of this footprint.
        /// </summary>
        public void SetPoints(params LatLong[] points) {
            Points = new ReadOnlyCollection<LatLong>(points.ToList());
        }

        /// <summary>
        /// Set the points that form the bounds of this footprint.
        /// </summary>
        public void SetPoints(IEnumerable<LatLong> points) {
            Points = new ReadOnlyCollection<LatLong>(points.ToList());
        }

        /// <summary>
        /// Shortest angle between angleRads and the center longitude.
        /// </summary>
        private double DeltaCenterLongRads(double angleRads) {
            if (angleRads > Math.PI || angleRads < -Math.PI) {
                throw new ArgumentOutOfRangeException();
            }

            var delta = angleRads - Center.LongRads;

            if (delta > Math.PI) {
                delta -= Math.PI * 2;
            } else if (delta < -Math.PI) {
                delta += Math.PI * 2;
            }

            return delta;
        }  

        /// <summary>
        /// Get the furthest east and western longitudes from this footprint.
        /// Accounts for footprints that span 0 and 180 degree longitudes.
        /// </summary>
        private (double westRads, double eastRads) GetLongitudeBounds() {
            var deltaMin = double.MaxValue;
            var deltaMax = double.MinValue;
            var longWest = 0d;
            var longEast = 0d;
            foreach(var longRad in Points.Select(p => p.LongRads)) {
                var deltaLong = DeltaCenterLongRads(longRad);
                if (deltaLong > deltaMax) {
                    deltaMax = deltaLong;
                    longEast = longRad;
                }

                if (deltaLong < deltaMin) {
                    deltaMin = deltaLong;
                    longWest = longRad;
                }
            }

            return (longWest, longEast);
        }
    }
}
