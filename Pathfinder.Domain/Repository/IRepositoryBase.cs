using System.Collections.Generic;

namespace Pathfinder.Domain.Repository
{
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();
    }
}