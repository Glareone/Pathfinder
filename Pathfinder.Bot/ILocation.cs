using System;

namespace Pathfinder.Bot
{
    public interface ILocation : IEquatable<ILocation>
    {
        /// <summary>
        /// Gets the row of this location.
        /// </summary>
        int Row { get; }

        /// <summary>
        /// Gets the column of this location.
        /// </summary>
        int Col { get; }
    }
}