using NUnit.Framework;
using SatImageUtilities.GeoPos;
using Newtonsoft.Json;

namespace SatImageUtilities.Tests
{
    public class GeoPosTests
    {
        [Test]
        public void TestSerialization()
        {
            var latLong = new LatLong(23, 42);
            var serialized = JsonConvert.SerializeObject(latLong);
            var deserialized = JsonConvert.DeserializeObject<LatLong>(serialized);

            Assert.AreEqual(latLong, deserialized);
        }

        [TestCase(53, -114, "N53W114")]
        [TestCase(0, 0, "N00E000")]
        [TestCase(-30, 60, "S30E060")]
        public void TestWholeNLatELong(double latDegs, double longDegs, string expected) {
            var latLong = new LatLong(latDegs, longDegs);

            Assert.AreEqual(expected, latLong.WholeNLatELong);
        }

        [TestCase(0, 6378137)]
        [TestCase(90, 6356752)]
        [TestCase(-90, 6356752)]
        [TestCase(45, 6367489.3880611947)]
        public void TestSeaLevelAtPosition(int latDegs, double seaLevel) {
            var latLong = new LatLong(latDegs, 0);
            var computedSeaLevel = GeoPosition.SeaLevelAtLatLong(latLong);

            Assert.AreEqual(seaLevel, computedSeaLevel);
        }
    }
}