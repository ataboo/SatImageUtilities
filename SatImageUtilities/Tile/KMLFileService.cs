using SatImageUtilities.GeoPos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace SatImageUtilities.Tile
{
    public class KMLFileService : IKMLFileService
    {
        public async Task<S2ATileFootprintCollection> LoadFromKMLFile(string kmlFilePath)
        {
            var settings = new XmlReaderSettings
            {
                IgnoreWhitespace = false,
                Async = true
            };


            var rawTiles = new List<(string name, string rawCenter, string[] rawCoords)>();
            using (var kmlMem = new MemoryStream())
            {
                using (var kmlFile = File.OpenRead(kmlFilePath))
                {
                    await kmlFile.CopyToAsync(kmlMem);
                }

                kmlMem.Position = 0;
                using (var xReader = XmlReader.Create(kmlMem, settings))
                {
                    while (!xReader.EOF)
                    {
                        await xReader.ReadAsync();

                        if (xReader.NodeType == XmlNodeType.Element)
                        {
                            if (xReader.LocalName == "Placemark")
                            {
                                rawTiles.Add(await ParsePlacemark(xReader));
                            }
                        }
                    }
                }
            }

            var footPrints = await Task.WhenAll(rawTiles.Select(t => Task.Run(() => {
                return new S2ATileFootprint
                {
                    TilePosition = new S2ATilePosition(t.name),
                    Center = ParseCoordinate(t.rawCenter),
                    Points = new System.Collections.ObjectModel.ReadOnlyCollection<LatLong>(t.rawCoords.Select(c => ParseCoordinate(c)).OfType<LatLong>().ToList()),
                };
            })));

            return new S2ATileFootprintCollection
            {
                Footprints = footPrints.ToDictionary(f => f.TilePosition, f => f),
                KMLFile = kmlFilePath,
                CompileDate = DateTime.Now
            };
        }

        private async Task<(string name, string rawCenter, string[] rawCoords)> ParsePlacemark(XmlReader reader)
        {
            var rawCoords = new List<string>();
            string centerPointRaw = null;
            string name = null;

            await reader.ReadToNodeEnd("Placemark", async (r) => {
                if (r.NodeType == XmlNodeType.Element) {
                    switch(reader.LocalName)
                    {
                        case "name":
                            await reader.ReadAsync();
                            name = reader.Value;
                            break;
                        case "LinearRing":
                            rawCoords.AddRange(await ReadCoordinates(reader));
                            break;
                        case "Point":
                            centerPointRaw = (await ReadCoordinates(reader))[0];
                            break;
                        default:
                            break;
                    }
                }
            });

            if (centerPointRaw == null) {
                Console.WriteLine("but why?");
            }

            return (name, centerPointRaw, rawCoords.ToArray());
        }

        private async Task<string[]> ReadCoordinates(XmlReader reader) {
            string coordinateLine = "";
            
            await reader.ReadToNodeEnd("coordinates", async (r) => {
                if (r.NodeType == XmlNodeType.Element && r.LocalName == "coordinates") {
                    await r.ReadAsync();
                    coordinateLine = r.Value;
                    return;
                }
            });

            return coordinateLine.Split(' ');
        }

        private LatLong ParseCoordinate(string rawCoordinate) {
            var splitCoord = rawCoordinate.Split(',');
            if (splitCoord.Length != 3) {
                return null;
            }

            return new LatLong(double.Parse(splitCoord[1]), double.Parse(splitCoord[0]));
        }
    }
}
