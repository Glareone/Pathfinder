using System;

namespace Pathfinder.Bot
{
    public class Player : Location, IEquatable<Player>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Player"/> class
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="id"></param>
        public Player(int row, int col, int id) : base(row, col)
        {
            Id = id;
        }

        //Player' identificator
        public int Id {get;set;}

        /// <summary>
        /// Gets the team of this player.
        /// </summary>
        public int Team { get; set; }

        /// <summary>
        /// Gets view radius bonus
        /// </summary>
        public double ViewRadiusBonus { get; set; }

        /// <summary>
        /// Gets speed bonus
        /// </summary>
        public double SpeedBonus { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Player) obj);
        }

        public bool Equals(Player other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Id == other.Id && Team == other.Team && ViewRadiusBonus.Equals(other.ViewRadiusBonus) && SpeedBonus.Equals(other.SpeedBonus);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ Id;
                hashCode = (hashCode * 397) ^ Team;
                hashCode = (hashCode * 397) ^ ViewRadiusBonus.GetHashCode();
                hashCode = (hashCode * 397) ^ SpeedBonus.GetHashCode();
                return hashCode;
            }
        }
    }
}