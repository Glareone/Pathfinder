using System;

namespace Pathfinder.Domain
{
    public class Tile : Location, IEquatable<Tile>
    {
        public Tile(int row, int col, int? cost)
            : base(row, col)
        {
            Cost = cost;
        }

        /// <summary>
        /// Cost of moving on this tile
        /// </summary>
        public int? Cost { get; set; }

        public bool Equals(Tile other)
        {
            return base.Equals(other) && other.Cost == Cost;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Col;
                result = (result*397) ^ Row;
                result = (result*397) ^ Cost.GetValueOrDefault(int.MaxValue);
                return result;
            }
        }
    }
}