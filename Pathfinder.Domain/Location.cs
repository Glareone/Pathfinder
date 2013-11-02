using Pathfinder.Bot;

namespace Pathfinder.Domain
{
    public class Location : ILocation
    {
        public Location(int row, int col)
        {
            Row = row;
            Col = col;
        }

        /// <summary>
        /// Gets the row of this location.
        /// </summary>
        public int Row { get; private set; }

        /// <summary>
        /// Gets the column of this location.
        /// </summary>
        public int Col { get; private set; }

        public bool Equals(ILocation other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return other.Row == Row && other.Col == Col;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != typeof (ILocation))
                return false;

            return Equals((ILocation) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Row*397) ^ Col;
            }
        }
    }
}