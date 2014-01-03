using System.Collections.Generic;

namespace Pathfinder.Domain.Repository
{
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Gets entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// Saves entity
        /// </summary>
        /// <param name="entity"></param>
        void Save(T entity);
    }
}