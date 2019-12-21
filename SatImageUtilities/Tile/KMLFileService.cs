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


            var rawTiles = new List<(string name, string[] rawCoords)>();
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
                    Points = ParseLinearRingCoordinates(t.rawCoords),
                };
            })));

            return new S2ATileFootprintCollection
            {
                Footprints = footPrints.ToDictionary(f => f.TilePosition, f => f),
                KMLFile = kmlFilePath,
                CompileDate = DateTime.Now
            };
        }

        private async Task<(string name, string[] rawCoords)> ParsePlacemark(XmlReader reader)
        {
            var rawCoords = new List<string>();
            string name = null;

            while (true)
            {
                await reader.ReadAsync();
                
                switch(reader.NodeType)
                {
                    case XmlNodeType.Element:
                        switch(reader.LocalName)
                        {
                            case "name":
                                await reader.ReadAsync();
                                name = reader.Value;
                                break;
                            case "coordinates":
                                await reader.ReadAsync();
                                var coordString = reader.Value;
                                rawCoords.AddRange(coordString.Trim().Split(' '));
                                break;
                            default:
                                break;
                        }
                        break;

                    case XmlNodeType.EndElement:
                        if (reader.LocalName == "Placemark")
                        {
                            return (name, rawCoords.ToArray());
                        }
                        break;
                    default:
                        break;
                }
            }

            throw new Exception("Failed to reach end of placemark.");
        }

        private LatLong[] ParseLinearRingCoordinates(string[] coordinateStrings)
        {
            return coordinateStrings.Select(s => {
                var split = s.Split(',');
                return new LatLong(double.Parse(split[1]), double.Parse(split[0]));
            }).ToArray();
        }
    }
}
