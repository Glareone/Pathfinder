namespace Pathfinder.Domain.Tiles
{
    public class ArtifactTile : Tile
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ArtifactTile"/> class
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="artifactId"></param>
        public ArtifactTile(Tile tile, int artifactId) : this(tile.Row, tile.Col, tile.Cost, artifactId)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ArtifactTile"/> class
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="cost"></param>
        /// <param name="artifactId"></param>
        public ArtifactTile(int row, int col, int cost, int artifactId)
            : base(row, col, cost)
        {
            ArtifactId = artifactId;
        }

        /// <summary>
        /// Artifact id
        /// </summary>
        public int ArtifactId { get; set; }
    }
}