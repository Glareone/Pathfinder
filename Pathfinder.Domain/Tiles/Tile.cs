using System;

using Pathfinder.Bot;

namespace Pathfinder.Domain.Tiles
{
    public class Tile : Location, IEquatable<Tile>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Tile"/> class
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="cost"></param>
        public Tile(int row, int col, int cost)
            : base(row, col)
        {
            this.Cost = cost;
        }

        /// <summary>
        /// Cost of moving on this tile
        /// </summary>
        public int Cost { get; set; }

        public bool Equals(Tile other)
        {
            return base.Equals(other) && other.Cost == this.Cost;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = this.Col;
                result = (result*397) ^ this.Row;
                result = (result*397) ^ this.Cost;
                return result;
            }
        }
    }
}