using System;

namespace SatImageUtilities.Tile
{ 
    public class S2ATilePosition
    {
        public string LatZone { get; set; }

        public int LongZone { get; set; }

        public string Digraph { get; set; }

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
