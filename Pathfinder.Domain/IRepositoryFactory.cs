using Pathfinder.Domain.Repository;

namespace Pathfinder.Domain
{
    public interface IRepositoryFactory
    {
        /// <summary>
        /// Gets content repository
        /// </summary>
        /// <returns></returns>
        IContentRepository GetContentRepository();

        /// <summary>
        /// Gets Artifact repository
        /// </summary>
        /// <returns></returns>
        IArtifactRepository GetArtifactRepository();
    }
}