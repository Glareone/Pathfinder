using Pathfinder.Data.Repository;
using Pathfinder.Domain;
using Pathfinder.Domain.Repository;

namespace Pathfinder.Data
{
    public abstract class RepositoryFactory : IRepositoryFactory
    {
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
        public virtual IMapRepository GetMapRepository()
        {
            return new MapRepository();
        }

        /// <summary>
        /// Gets user repository
        /// </summary>
        /// <returns></returns>
        public abstract IUserRepository GetUserRepository();

        /// <summary>
        /// Gets person repository
        /// </summary>
        /// <returns></returns>
        public abstract IPersonRepository GetPersonRepository();

        /// <summary>
        /// Gets bot repository
        /// </summary>
        /// <returns></returns>
        public abstract IBotRepository GetBotRepository();
    }
}
