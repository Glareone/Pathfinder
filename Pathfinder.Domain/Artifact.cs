using Pathfinder.Bot;

namespace Pathfinder.Domain
{
    public class Artifact : Location, IArtifact
    {
        public Artifact(int row, int col, int id)
            : base(row, col)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the identification of this artifact.
        /// </summary>
        public int Id { get; private set; }

        public bool Equals(IArtifact other)
        {
            return base.Equals(other) && other.Id == Id;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Col;
                result = (result*397) ^ Row;
                result = (result*397) ^ Id;
                return result;
            }
        }
    }
}