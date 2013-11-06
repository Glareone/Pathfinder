using System.Collections.Generic;

namespace Pathfinder.Bot
{
    public interface IGameState
    {
        /// <summary>
        /// Gets the width of the map.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Gets the height of the map.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Gets the allowed loading time remaining in milliseconds
        /// </summary>
        int LoadingTimeRemaining { get; }

        /// <summary>
        /// Gets the allowed turn time remaining in milliseconds.
        /// </summary>
        int TimeRemaining { get; }

        /// <summary>
        /// Current turn
        /// </summary>
        int Turn { get; }

        /// <summary>
        /// Maximum available turns count
        /// </summary>
        int Turns { get; }

        /// <summary>
        /// View radius
        /// </summary>
        int ViewRadius { get; }

        /// <summary>
        /// Gets your current location.
        /// </summary>
        Player Me { get; }

        /// <summary>
        /// Gets whether <paramref name="location"/> is passable or not.
        /// </summary>
        /// <param name="location">The location to check.</param>
        /// <returns><c>true</c> if the location is not water, <c>false</c> otherwise.</returns>
        bool IsPassable(Location location);

        /// <summary>
        /// Gets cost of moving on this location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        int GetPassCost(Location location);

        /// <summary>
        /// Checks if visible
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        bool IsVisible(Location loc);

        /// <summary>
        /// Checks if enemy
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        bool IsEnemy(Location loc);

        /// <summary>
        /// Checks if chest
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        bool IsChest(Location loc);

        /// <summary>
        /// Checks if exit from location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        bool IsExit(Location location);

        /// <summary>
        /// Gets destination
        /// </summary>
        /// <param name="loc"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        Location GetDestination(Location loc, Direction direction);

        /// <summary>
        /// Gets the distance between <paramref name="loc1"/> and <paramref name="loc2"/>.
        /// </summary>
        /// <param name="loc1">The first location to measure with.</param>
        /// <param name="loc2">The second location to measure with.</param>
        /// <returns>The distance between <paramref name="loc1"/> and <paramref name="loc2"/></returns>
        int GetDistance(Location loc1, Location loc2);

        /// <summary>
        /// Gets aims
        /// </summary>
        IDictionary<Direction, Location> Aim { get; }
    }
}