using NUnit.Framework;
using SatImageUtilities.GeoPos;

namespace SatImageUtilities.Tests {
    internal static class TestExtensions {
        public static void AssertEqual(this LatLong pointA, LatLong pointB, double tolerance = 1e-6) {
            Assert.AreEqual(pointB.LongRads, pointA.LongRads, tolerance);
            Assert.AreEqual(pointB.LatRads, pointA.LatRads, tolerance);
        }
    }
}