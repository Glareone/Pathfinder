using System;

namespace Pathfinder.Bot
{
    public class Chest : Location, IEquatable<Chest>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Chest"/> class
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="id"></param>
        public Chest(int row, int col, int id) : base(row, col)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the identification of this chest.
        /// </summary>
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public bool Equals(Chest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Id == other.Id;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ Id;
            }
        }
    }
}