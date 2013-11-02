using System;

namespace Pathfinder.Bot
{
    public interface IArtifact : ILocation, IEquatable<IArtifact>
    {
        /// <summary>
        /// Gets the identification of this artifact.
        /// </summary>
        int Id { get; }
    }
}