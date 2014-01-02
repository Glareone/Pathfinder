using System.Collections.Generic;
using System.Data.Entity;

using Pathfinder.Domain.Repository;

namespace Pathfinder.Data.SqlServer.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    {
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        public abstract List<T> GetAll();
    }
}