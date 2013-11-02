using System;

namespace Pathfinder.Bot
{
    public interface IPlayer : ILocation, IEquatable<IPlayer>
    {
        /// <summary>
        /// Gets the team of this player.
        /// </summary>
        int Team { get; }

        /// <summary>
        /// Gets view radius bonus
        /// </summary>
        int ViewRadiusBonus { get; }
    }
}