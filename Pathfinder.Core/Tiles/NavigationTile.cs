namespace Pathfinder.Core.Tiles
{
    public class NavigationTile : Tile
    {
         /// <summary>
        /// Initializes a new instance of <see cref="NavigationTile"/> class
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="spot"></param>
        public NavigationTile(Tile tile, SpotType spot)
            : this(tile.Row, tile.Col, tile.Cost, spot)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="NavigationTile"/> class
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="cost"></param>
        /// <param name="spot"></param>
        public NavigationTile(int row, int col, int cost, SpotType spot)
            : base(row, col, cost)
        {
            Spot = spot;
        }

        /// <summary>
        /// Spot type
        /// </summary>
        public SpotType Spot { get; set; }
    }
}