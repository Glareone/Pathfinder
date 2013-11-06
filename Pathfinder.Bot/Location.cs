using System;

namespace Pathfinder.Bot
{
    public class Location : IEquatable<Location>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Location"/> class
        /// </summary>
        public Location(int row, int col)
        {
            Row = row;
            Col = col;
        }

        /// <summary>
        /// Gets the row of this location.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Gets the column of this location.
        /// </summary>
        public int Col { get; set; }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Location other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Row == other.Row && Col == other.Col;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Location) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Row * 397) ^ Col;
            }
        }
    }
}