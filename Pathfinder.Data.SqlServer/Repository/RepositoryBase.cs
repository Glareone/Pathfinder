using System.Collections.Generic;

using Pathfinder.Domain.Repository;

namespace Pathfinder.Data.SqlServer.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    {
        /// <summary>
        /// Gets entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract T Get(int id);

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        public abstract List<T> GetAll();

        /// <summary>
        /// Saves entity
        /// </summary>
        /// <param name="entity"></param>
        public abstract void Save(T entity);
    }
}