using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using SatImageUtilities.GeoPos;
using SatImageUtilities.Tile;

namespace SatImageUtilities.Tests {
    public class S2AFootprintTests {
        [Test]
        [Ignore("Just and example of parsing an S2 KML")]
        public async Task WriteKmlToJson() {
            var service = new KMLFileService();

            var footprints = await service.LoadFromKMLFile("s2_footprints.kml");

            using var writer = File.CreateText("s2_footprints.json");
            writer.Write(JsonConvert.SerializeObject(footprints));
        }

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
                    new LatLong(5, -5),
                    new LatLong(-5, -5)
                }.ToList()),
                Center = new LatLong(0, 0)
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
            footprint.Center = new LatLong(25, 25);

            (ne, sw) = footprint.Bounds;

            ne.AssertEqual(new LatLong(30, 30));
            sw.AssertEqual(new LatLong(20, 20));
            Assert.IsFalse(footprint.SpansIDL);

            footprint.Points = new ReadOnlyCollection<LatLong>(new []{new LatLong(5, 179), new LatLong(5, 0), new LatLong(-5, 179), new LatLong(-5, 0)}.ToList());
            footprint.Center = new LatLong(0, 179.5);

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
                }.ToList()),
                Center = new LatLong(0, 180)
            };

            var (ne, sw) = footprint.Bounds;

            // Look at the IDL if this is confusing.
            ne.AssertEqual(new LatLong(5, -175));
            sw.AssertEqual(new LatLong(-5, 175));
            Assert.IsTrue(footprint.SpansIDL);

            footprint.Points = new ReadOnlyCollection<LatLong>(new LatLong[] {
                new LatLong(5, 91),
                new LatLong(5, -91),
                new LatLong(-5, 91),
                new LatLong(-5, -91)
            }.ToList());
            footprint.Center = new LatLong(0, -180);

            (ne, sw) = footprint.Bounds;

            ne.AssertEqual(new LatLong(5, -91));
            sw.AssertEqual(new LatLong(-5, 91));
            Assert.IsTrue(footprint.SpansIDL);
        }

        // Center of footprint
        [TestCase(0, 0, true)]
        // On corners of footprint
        [TestCase(-10, -10, true)]
        [TestCase(-10, 10, true)]
        [TestCase(10, -10, true)]
        [TestCase(10, 10, true)]
        // Outside of footprint
        [TestCase(10.001, 0, false)]
        [TestCase(-10.001, 0, false)]
        [TestCase(0,10.001, false)]
        [TestCase(0, -10.001, false)]
        [TestCase(10.001, 10.001, false)]
        [TestCase(10.001, -10.001, false)]
        [TestCase(-10.001, -10.001, false)]
        [TestCase(-10.001, 10.001, false)]
        public void TestPointInsideBoundsSpanningZero(double latDeg, double longDeg, bool expectedInside) {
            var point = new LatLong(latDeg, longDeg);
            
            var footprint = new S2ATileFootprint {
                Center = new LatLong(0, 0)
            };
            footprint.SetPoints(new LatLong(-10, -10), new LatLong(-10, 10), new LatLong(10, 10), new LatLong(10, -10));

            Assert.AreEqual(expectedInside, footprint.ContainsPoint(point));
        }

        // Center of footprint
        [TestCase(30, 180, true)]
        [TestCase(30, -180, true)]
        // On Corners of footprint
        [TestCase(40, 170, true)]
        [TestCase(40, -170, true)]
        [TestCase(20, 170, true)]
        [TestCase(20, -170, true)]
        // Outside footprint
        [TestCase(40.001, 180, false)]
        [TestCase(19.999, -180, false)]
        [TestCase(30,169.999, false)]
        [TestCase(30, -169.999, false)]
        public void TestPointInsideBoundsSpanningIDL(double latDeg, double longDeg, bool expectedInside) {
            var point = new LatLong(latDeg, longDeg);
            
            var footprint = new S2ATileFootprint {
                Center = new LatLong(30, 180),
            };
            footprint.SetPoints(new LatLong(40, 170), new LatLong(20, 170), new LatLong(20, -170), new LatLong(40, -170));

            Assert.AreEqual(expectedInside, footprint.ContainsPoint(point));
        }

        // Center of footprint
        [TestCase(-30, 90, true)]
        // On Corners of footprint
        [TestCase(-40, 80, true)]
        [TestCase(-40, 100, true)]
        [TestCase(-20, 80, true)]
        [TestCase(-20, 100, true)]
        // Outside footprint
        [TestCase(-40.001, 90, false)]
        [TestCase(-19.999, 90, false)]
        [TestCase(-30,79.999, false)]
        [TestCase(-30, 100.001, false)]
        public void TestPointNotSpanning(double latDeg, double longDeg, bool expectedInside) {
            var point = new LatLong(latDeg, longDeg);
            
            var footprint = new S2ATileFootprint {
                Center = new LatLong(-30, 90)
            };
            footprint.SetPoints(new LatLong(-20, 80), new LatLong(-40, 80), new LatLong(-40, 100), new LatLong(-20, 100));

            Assert.AreEqual(expectedInside, footprint.ContainsPoint(point));
        }
    }
}