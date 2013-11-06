using System.Collections.Generic;
using Pathfinder.Domain.Repository;

namespace Pathfinder.Data.Repository
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