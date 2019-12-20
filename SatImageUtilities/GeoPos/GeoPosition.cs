
using System;

namespace SatImageUtilities.GeoPos
{
    public static class GeoPosition
    {
        private const double EquatorRadius = 6378137;
        private const double PoleRadius = 6356752;

        /// <summary>
        /// Get Earth's sea level at a position.
        /// </summary>
        public static double SeaLevelAtLatLong(LatLong latLong)
        {
            // R = √ [ (r1² *cos(B))² + (r2² * sin(B))² ] / [ (r1 * cos(B))² + (r2* sin(B))² ] 

            var r1 = EquatorRadius;
            var r2 = PoleRadius;

            var r1cosB = r1 * Math.Cos(latLong.LatRads);
            var r2sinB = r2 * Math.Sin(latLong.LatRads);

            return Math.Sqrt((r1 * r1 * r1cosB * r1cosB + r2 * r2 * r2sinB * r2sinB) / (r1cosB * r1cosB + r2sinB * r2sinB));   
        }
    }
}
