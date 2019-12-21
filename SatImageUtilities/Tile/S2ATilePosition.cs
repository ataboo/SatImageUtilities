using System;
using Newtonsoft.Json;

namespace SatImageUtilities.Tile
{ 
    [Serializable]
    public class S2ATilePosition
    {
        [JsonProperty("lat")]
        public string LatZone { get; set; }

        [JsonProperty("long")]
        public int LongZone { get; set; }

        [JsonProperty("digraph")]
        public string Digraph { get; set; }

        public S2ATilePosition() { }
        public S2ATilePosition(int longZone, string latZone, string digraph)
        {
            LongZone = longZone;
            LatZone = latZone;
            Digraph = digraph;
        }

        public S2ATilePosition(string name)
        {
            if (name.Length != 5)
            {
                throw new ArgumentException("Expected name with length of 5");
            }

            LongZone = int.Parse(name.Substring(0, 2));
            LatZone = name.Substring(2, 1);
            Digraph = name.Substring(3, 2);
        }

        public static explicit operator S2ATilePosition(string strVal) {
            return new S2ATilePosition(strVal);
        }

        public override string ToString()
        {
            return $"{LongZone.ToString("D2")}{LatZone}{Digraph}";
        }

        public override bool Equals(object obj)
        {
            return obj is S2ATilePosition otherPos && ToString().Equals(otherPos.ToString());
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
