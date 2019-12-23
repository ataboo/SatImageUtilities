using NUnit.Framework;
using SatImageUtilities.GeoPos;
using Newtonsoft.Json;
using SatImageUtilities.Tile;
using System.Collections.ObjectModel;
using System.Linq;

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

        [Test]
        public void TestFootprintBounds() {
            var footprint = new S2ATileFootprint {
                Points = new ReadOnlyCollection<LatLong>(new LatLong[]{
                    new LatLong(-5, 5),
                    new LatLong(5, 5),
                    new LatLong(0, 0),
                    new LatLong(5, -5),
                    new LatLong(-5, -5)
                }.ToList())
            };

            var (ne, sw) = footprint.Bounds;

            ne.AssertEqual(new LatLong(5, 5));
            sw.AssertEqual(new LatLong(-5, -5));
            Assert.IsFalse(footprint.SpansIDL);

            footprint.Points = new ReadOnlyCollection<LatLong> (new LatLong[]{
                new LatLong(30, 30),
                new LatLong(30, 20),
                new LatLong(20, 20),
                new LatLong(20, 30)
            }.ToList());

            (ne, sw) = footprint.Bounds;

            ne.AssertEqual(new LatLong(30, 30));
            sw.AssertEqual(new LatLong(20, 20));
            Assert.IsFalse(footprint.SpansIDL);

            footprint.Points = new ReadOnlyCollection<LatLong>(new []{new LatLong(5, 179), new LatLong(5, 0), new LatLong(-5, 179), new LatLong(-5, 0)}.ToList());

            (ne, sw) = footprint.Bounds;
            
            ne.AssertEqual(new LatLong(5, 179));
            sw.AssertEqual(new LatLong(-5, 0));
            Assert.IsFalse(footprint.SpansIDL);
        }

        [Test]
        public void TestFootprintBoundsCrossIDL() {
            var footprint = new S2ATileFootprint {
                Points = new ReadOnlyCollection<LatLong>(new LatLong[]{
                    new LatLong(5, -175),
                    new LatLong(5, -180),
                    new LatLong(-5, -180),
                    new LatLong(-5, -175),
                    new LatLong(0, -180),
                    new LatLong(5, 175),
                    new LatLong(5, 180),
                    new LatLong(-5, 180),
                    new LatLong(-5, 175),
                }.ToList())
            };

            var (ne, sw) = footprint.Bounds;

            ne.AssertEqual(new LatLong(5, 175));
            sw.AssertEqual(new LatLong(-5, -175));
            Assert.IsTrue(footprint.SpansIDL);

            footprint.Points = new ReadOnlyCollection<LatLong>(new LatLong[] {
                new LatLong(5, 91),
                new LatLong(5, -91),
                new LatLong(-5, 91),
                new LatLong(-5, -91)
            }.ToList());

            (ne, sw) = footprint.Bounds;

            ne.AssertEqual(new LatLong(5, 91));
            sw.AssertEqual(new LatLong(-5, -91));
            Assert.IsTrue(footprint.SpansIDL);
        }

    }
}