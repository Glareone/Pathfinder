using Pathfinder.Core.Tiles;

namespace Pathfinder.Engine
{
    public class GameLevel
    {
         /// <summary>
        /// Initializes a new instance of <see cref="GameLevel"/> class
        /// </summary>
        public GameLevel(Tile[,] tiles)
        {
            Tiles = tiles;
        }

        /// <summary>
        /// Tiles collection
        /// </summary>
        public Tile[,] Tiles
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the width of the map.
        /// </summary>
        public int Width
        {
            get
            {
                return Tiles.GetLength(0);
            }
        }

        /// <summary>
        /// Gets the height of the map.
        /// </summary>
        public int Height
        {
            get
            {
                return Tiles.GetLength(1);
            }
        }
    }
}