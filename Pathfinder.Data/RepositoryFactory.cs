using Pathfinder.Data.Repository;
using Pathfinder.Domain;
using Pathfinder.Domain.Repository;

namespace Pathfinder.Data
{
    public abstract class RepositoryFactory : IRepositoryFactory
    {
        /// <summary>
        /// Person repository instance
        /// </summary>
        public IPersonRepository PersonRepository { get; set; }

        /// <summary>
        /// Gets content repository
        /// </summary>
        /// <returns></returns>
        public IContentRepository GetContentRepository()
        {
            return new ContentRepository();
        }

        /// <summary>
        /// Gets Artifact repository
        /// </summary>
        /// <returns></returns>
        public IArtifactRepository GetArtifactRepository()
        {
            return new ArtifactRepository();
        }

        /// <summary>
        /// Gets Map repository
        /// </summary>
        /// <returns></returns>
        public IMapRepository GetMapRepository()
        {
            return new MapRepository();
        }

        /// <summary>
        /// Gets person repository
        /// </summary>
        /// <returns></returns>
        public abstract IPersonRepository GetPersonRepository();
    }
}
