using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pathfinder.Data.Repository;
using Pathfinder.Domain;
using Pathfinder.Domain.Repository;

namespace Pathfinder.Data
{
    public class RepositoryFactory : IRepositoryFactory
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
    }
}
