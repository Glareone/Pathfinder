using Pathfinder.Domain.Tiles;

namespace Pathfinder.Domain.Entities
{
    public class Map : DomainEntity
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Map"/> class
        /// </summary>
        public Map(Tile[,] tiles)
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

        /// <summary>
        /// Saves instance
        /// </summary>
        public override void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}