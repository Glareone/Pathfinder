using System;

using Pathfinder.Core.Tiles;
using Pathfinder.Domain.Entities;

using TiledSharp;

namespace Pathfinder.Engine.Builders
{
    public class GameLevelBuilder
    {
        /// <summary>
        /// Initializes a new instance of <see cref="GameLevelBuilder"/> class
        /// </summary>
        public GameLevelBuilder(TmxMap tmxMap)
        {
            TmxMap = tmxMap;
        }

        /// <summary>
        /// Tmx map
        /// </summary>
        protected TmxMap TmxMap { get; private set; }

        /// <summary>
        /// Builds map
        /// </summary>
        /// <returns></returns>
        public GameLevel Build()
        {
            return new GameLevel(LoadTiles());
        }

        /// <summary>
        /// Loads tiles
        /// </summary>
        /// <returns></returns>
        public Tile[,] LoadTiles()
        {
            var tiles = new Tile[TmxMap.Height, TmxMap.Width];
            for (int row = 0; row < TmxMap.Height; row++)
            {
                for (int col = 0; col < TmxMap.Width; col++)
                {
                    tiles[row, col] = new Tile(row, col, int.MaxValue);
                }
            }
            
            var tmxTiles = TmxMap.Layers["Tiles"];
            if (tmxTiles == null)
            {
                throw new InvalidOperationException("Unable to load 'Tiles' layer.");
            }

            var zeroCost = int.Parse(tmxTiles.Properties["min"]);
            var unwalkable = int.Parse(tmxTiles.Properties["max"]) - zeroCost;

            foreach (var tmxTile in tmxTiles.Tiles)
            {
                if (tmxTile.Gid < zeroCost)
                {
                    continue;
                }

                var cost = tmxTile.Gid - zeroCost + 1;
                tiles[tmxTile.Y, tmxTile.X] = new Tile(tmxTile.Y, tmxTile.X, cost < unwalkable ? cost : int.MaxValue);
            }

            var tmxArtifacts = TmxMap.Layers["Artifacts"];
            if (tmxArtifacts == null)
            {
                throw new InvalidOperationException("Unable to load 'Artifacts' layer.");
            }

            var zeroArtifact = int.Parse(tmxArtifacts.Properties["min"]);

            foreach (var tmxTile in tmxArtifacts.Tiles)
            {
                if (tmxTile.Gid < zeroArtifact)
                {
                    continue;
                }

                tiles[tmxTile.Y, tmxTile.X] = new ArtifactTile(tiles[tmxTile.Y, tmxTile.X], tmxTile.Gid - zeroArtifact + 1);
            }

            var tmxNavigation = TmxMap.Layers["Navigation"];

            if (tmxNavigation == null)
            {
                throw new InvalidOperationException("Unable to load 'Navigation' layer.");
            }

            var zeroNavigation = int.Parse(tmxNavigation.Properties["min"]);

            foreach (var tmxTile in tmxNavigation.Tiles)
            {
                if (tmxTile.Gid < zeroNavigation)
                {
                    continue;
                }

                tiles[tmxTile.Y, tmxTile.X] = new NavigationTile(tiles[tmxTile.Y, tmxTile.X], (SpotType)(tmxTile.Gid - zeroNavigation + 1));
            }

            return tiles;
        }
    }
}