using Pathfinder.Bot;

namespace Pathfinder.Domain
{
    public class Player : Location, IPlayer
    {
        public Player(int row, int col, int team)
            : base(row, col)
        {
            Team = team;
        }

        /// <summary>
        /// Gets the team of this player.
        /// </summary>
        public int Team { get; private set; }

        /// <summary>
        /// Gets view radius bonus
        /// </summary>
        public int ViewRadiusBonus
        {
            get; set;
        }

        public bool Equals(IPlayer other)
        {
            return base.Equals(other) && other.Team == Team;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Col;
                result = (result*397) ^ Row;
                result = (result*397) ^ Team;
                return result;
            }
        }
    }
}