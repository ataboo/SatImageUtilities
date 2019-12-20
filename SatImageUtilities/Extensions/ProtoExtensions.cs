using SatImageUtilities.GeoPos;
using SatImageUtilities.Tile;
using Sentinal2Utilities.Tile.Proto;
using System;
using System.Linq;
using static Sentinal2Utilities.Tile.Proto.ProtoFootprintCollection.Types;

namespace SatImageUtilities.Extensions
{
    public static class ProtoExtensions
    {
        public static S2ATileFootprintCollection ToS2ACollection(this ProtoFootprintCollection proto)
        {
            return new S2ATileFootprintCollection
            {
                CompileDate = new DateTime((long)proto.CompileDate),
                Footprints = proto.Footprints.ToDictionary(f => new S2ATilePosition(f.TilePosition), f => new S2ATileFootprint
                {
                    Points = f.Coordinates.Select(c => new LatLong(c.Latitude, c.Longitude)).ToArray(),
                    TilePosition = new S2ATilePosition(f.TilePosition)
                }),
                KMLFile = proto.KMLFile,
            };
        }

        public static ProtoFootprintCollection ToProtoCollection(this S2ATileFootprintCollection collection)
        {
            var proto = new ProtoFootprintCollection()
            {
                CompileDate = (ulong)collection.CompileDate.Ticks,
                KMLFile = collection.KMLFile
            };

            proto.Footprints.AddRange(collection.Footprints.Select(f =>
            {
                var footPrint = new ProtoFootprint
                {
                    TilePosition = f.Value.TilePosition.ToString(),
                };

                footPrint.Coordinates.AddRange(f.Value.Points.Select(p => new ProtoCoordinate { Latitude = p.LatDeg, Longitude = p.LongDeg }));

                return footPrint;
            }));

            return proto;
        }

    }
}
